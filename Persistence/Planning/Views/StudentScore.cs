namespace Alorotbe.Persistence.Planning.Views
{
    public class StudentScore
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string MajorName { get; private set; }
        public string GradeName { get; private set; }
        public int TotalStudy { get; private set; }
        public int TotalTestCount { get; private set; }
        public int Score { get; set; }
    }
}
