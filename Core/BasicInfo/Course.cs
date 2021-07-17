namespace Core.BasicInfo
{
    public class Course
    {
        public int CourseId { get; private set; }
        public string CourseName { get; private set; }
        
        public int GroupId { get; private set; }
        public Group Group { get; private set; }
    }
}
