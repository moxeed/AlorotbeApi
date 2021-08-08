using System.ComponentModel.DataAnnotations.Schema;

namespace Alorotbe.Persistence.Planning.Views
{
    [NotMapped]
    public class StudentScore
    {
        public int UserId { get; private set;}
        public int? ProfileId { get; private set;}
        public string UserName { get; private set; }
        public int MajorId { get; private set; }
        public string MajorName { get; private set; }
        public int GradeId { get; private set; }
        public string GradeName { get; private set; }
        public int TotalStudy { get; private set; }
        public int TotalTestCount { get; private set; }
        public int Score { get; private set; }
    }
}
