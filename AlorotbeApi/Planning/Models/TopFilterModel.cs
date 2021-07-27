namespace Alorotbe.Api.Planning.Models
{
    public enum Period : short
    {
        Day = 1,
        Week = 7,
        Month = 30,
        Year = 365,
        All = short.MaxValue
    }

    public enum Criterion : byte 
    {
        Test,
        Time,
        Score
    }

    public class TopFilterModel
    {
        public int Period { get; set; }
        public int Criterion { get; set; }
        public int? GradeId { get; set; }
        public int Count { get; set; }
    }
}
