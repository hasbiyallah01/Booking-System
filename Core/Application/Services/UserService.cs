using System.Security.Claims;
using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Application.Interfaces.Services;
using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Entity.Models;
using Booking_System.Models;
using Booking_System.Models.UserModel;
using Google.Apis.Auth;

namespace Booking_System.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository,  IUnitOfWork unitOfWork, IHttpContextAccessor httpContext,
         IVerificationCodeRepository verificationCodeRepository, IEmailService emailService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _verificationCodeRepository = verificationCodeRepository;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<BaseResponse<UserResponse>> CreateUser(UserRequest request)
        {
            int randomCode = new Random().Next(10000, 99999);

            if (await _userRepository.ExistsAsync(request.Email))
            {
                return new BaseResponse<UserResponse>
                {
                    Message = "Email already exists!!!",
                    IsSuccessful = false
                };
            }
            else
            {
                if (request.Password != request.ConfirmPassword)
                {
                    return new BaseResponse<UserResponse>
                    {
                        Message = "Password does not match",
                        IsSuccessful = false
                    };
                }

                var user = new User
                {
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    FullName = request.FirstName + " " + request.LastName,
                    DateCreated = DateTime.UtcNow,
                    IsDeleted = false,
                    Role = Domain.Enum.Role.Student,
                    CreatedBy = "ManualRegistration",
                };


                var newUser = await _userRepository.AddAsync(user);

                var code = new  VerificationCode
                {
                    Code = randomCode,
                    UserId = newUser.Id,
                    DateCreated = DateTime.UtcNow,
                    IsVerified = false,
                    IsDeleted = false,
                    User = newUser,
                    CreatedOn = DateTime.UtcNow,
                };

                await _verificationCodeRepository.Create(code);

                try
                {
                    var mailRequest = new MailRequest
                    {
                        Subject = "Confirmation Code",
                        ToEmail = user.Email,
                        Title = "Your Confirmation Code",
                        HtmlContent = $"<html><body><h1>Hello {request.FirstName}, Welcome to Konsume.</h1><h4>Your confirmation code is {code.Code} to continue with the registration</h4></body></html>"
                    };

                    await _emailService.SendEmailAsync(user);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<UserResponse>
                    {
                        Message = $"An error occurred while sending email: {ex.Message}",
                        IsSuccessful = false
                    };
                }

                await _unitOfWork.SaveAsync();

                return new BaseResponse<UserResponse>
                {
                    Message = "Check your email and complete your registration",
                    IsSuccessful = true,
                    Value = new UserResponse
                    {
                        Id = user.Id,
                        FullName = request.FirstName + " " + request.LastName,
                        Email = user.Email,
                        Role = user.Role,
                    }
                };
            }
        }



        public async Task<BaseResponse<UserResponse>> GoogleLogin(string tokenId)
        {
            if (!tokenId.Contains("."))
            {
                return new BaseResponse<UserResponse>
                {
                    Message = "Invalid Google token format",
                    IsSuccessful = false
                };
            }

            var validationSettings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "237085518851-jofqas7qcl591ba3kqcj09dl177ikbh1.apps.googleusercontent.com" }
            };

            try
            {
                var googlePayload = await GoogleJsonWebSignature.ValidateAsync(tokenId, validationSettings);

                if (googlePayload == null)
                {
                    return new BaseResponse<UserResponse>
                    {
                        Message = "Invalid Google token",
                        IsSuccessful = false
                    };
                }

                var user = await _userRepository.GetUserByEmail(googlePayload.Email);

                if (user != null)
                {
                    var existingUserResponse = new UserResponse
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Role = user.Role
                    };

                    return new BaseResponse<UserResponse>
                    {
                        Message = "User logged in successfully",
                        IsSuccessful = true,
                        Value = existingUserResponse
                    };
                }
                else
                {

                    user = new User
                    {
                        FullName = googlePayload.GivenName + " " + googlePayload.FamilyName,
                        Email = googlePayload.Email,
                        DateCreated = DateTime.UtcNow,
                        IsDeleted = false,
                        Role = Domain.Enum.Role.Student,
                        CreatedBy = "GoogleOAuth",
                    };

                    try
                    {
                        var mailRequest = new MailRequest
                        {
                            Subject = "Welcome to Konsume!",
                            ToEmail = user.Email,
                            Title = "Welcome to Konsume!",
                            HtmlContent = $@"
                        <html>
                            <body>
                                <h1>Hello {googlePayload.GivenName} {googlePayload.FamilyName},</h1>
                                <p>Welcome to <strong>Konsume</strong>! We're excited to have you join our community.</p>
                                <p>If you have any questions or need assistance, feel free to <a href='mailto:reachKonsume@gmail.com'>contact us</a>.</p>
                                <p>Thank you for choosing Konsume! Let's get started!</p>
                            </body>
                        </html>"
                        };

                        await _emailService.SendEmailAsync(new MailReceiverRequest { Name = googlePayload.GivenName, Email = user.Email }, mailRequest);
                    }
                    catch (Exception ex)
                    {
                        return new BaseResponse<UserResponse>
                        {
                            Message = $"An error occurred while sending email: {ex.Message}",
                            IsSuccessful = false
                        };
                    }


                    var newUser = await _userRepository.AddAsync(user);
                    await _unitOfWork.SaveAsync();

                    var newUserResponse = new UserResponse
                    {
                        Id = user.Id,
                        FullName = googlePayload.GivenName + " " + googlePayload.FamilyName,
                        Email = user.Email,
                        Role = user.Role
                    };

                    return new BaseResponse<UserResponse>
                    {
                        Message = "Google user created successfully",
                        IsSuccessful = true,
                        Value = newUserResponse
                    };
                }
            }
            catch (InvalidJwtException ex)
            {
                return new BaseResponse<UserResponse>
                {
                    Message = $"JWT validation failed: {ex.Message}",
                    IsSuccessful = false
                };
            }
        }

        public async Task<BaseResponse<ICollection<UserResponse>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            return new BaseResponse<ICollection<UserResponse>>
            {
                Message = "List of users",
                IsSuccessful = true,
                Value = users.Select(user => new UserResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<UserResponse>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse<UserResponse>
                {
                    Message = "User not found",
                    IsSuccessful = false
                };
            }
            return new BaseResponse<UserResponse>
            {
                Message = "User successfully found",
                IsSuccessful = true,
                Value = new UserResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role,
                }
            };
        }

        public async Task<BaseResponse> RemoveUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    IsSuccessful = false
                };
            }

            _userRepository.RemoveUser(user);
            await _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                Message = "User deleted successfully",
                IsSuccessful = true
            };
        }

        public async Task<BaseResponse> UpdateUser(int id, UserRequest request)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse
                {
                    Message = "User does not exist",
                    IsSuccessful = false
                };
            }


            var exists = await _userRepository.ExistsAsync(request.Email, id);
            if (exists)
            {
                return new BaseResponse
                {
                    Message = "Email already exists!!!",
                    IsSuccessful = false
                };
            }

            if (request.Password != request.ConfirmPassword)
            {
                return new BaseResponse
                {
                    Message = "Password does not match",
                    IsSuccessful = false
                };
            }

            var loginUserId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            user.FullName = request.FirstName + " " + request.LastName;
            user.Email = request.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.IsDeleted = false;
            user.Role = Domain.Enum.Role.Student;
            user.DateModified = DateTime.UtcNow;
            user.ModifiedBy = loginUserId;

            _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                Message = "User updated successfully",
                IsSuccessful = true
            };
        }

        public async Task<BaseResponse<UserResponse>> Login(LoginRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user.Email == model.Email && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return new BaseResponse<UserResponse>
                {
                    Message = "Login Successfull",
                    IsSuccessful = true,
                    Value = new UserResponse
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Role = user.Role,
                    }
                };
            }
            return new BaseResponse<UserResponse>
            {
                Message = "Invalid Credentials",
                IsSuccessful = false
            };
        }
    }
}
