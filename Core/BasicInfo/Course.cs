using Alorotbe.Core.BasicInfo;

namespace Core.BasicInfo
{
    public class Course
    {
        public int CourseId { get; private set; }
        public string CourseName { get; private set; }
        
        public int MajorId { get; private set; }
        public Major Major { get; private set; }
    }
}
