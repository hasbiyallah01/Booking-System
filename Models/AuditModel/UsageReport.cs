namespace Booking_System.Models.AuditModel
{
    public class UsageReport
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int TotalBookings { get; set; }   
        public int TotalChcekIns { get; set; }
        public int NoShows { get; set; }
        public TimeSpan AverageSesssionDuration { get; set; }
        public int PeakOccupancy { get; set; }

    }

    public class PeakHour
    {
        public int Hour { get; set; }
        public int AverageOccupancy { get; set; }
        public int TotalBookings { get; set; }
    }

    public class FloorUsageReport
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int TotalBookings { get; set; }
        public int TotalCheckIns { get; set; }
        public double UnitilizationRate { get; set; }
        public IEnumerable<ZoneUsageReport> ZoneUsageReports { get; set; } = new List<ZoneUsageReport>();
    }

    public class  ZoneUsageReport
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int TotalBookings { get; set; }
        public int TotalChcekIns { get; set; }
        public double UnitilizationRate { get; set; }

    }

    public class DailyOccupancyTrend
    {
        public double AverageOccupancyRate { get; set; }   
        public DateOnly PeakDay { get; set; }
        public int PeakDayOccupancy { get; set; }
        public IEnumerable<DailyOccupancy> DailyOccupancies { get; set; } = new List<DailyOccupancy>();
    }

    public class DailyOccupancy
    {
        public DateOnly Date { get; set; }
        public int TotalBookings { get; set; }
        public int ChcekIns { get; set; }
        public double OccupancyRate { get; set; }
    }
}
