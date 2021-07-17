using System;
using Core.BasicInfo;

namespace Core.Planing
{
    public class CourseStudy
    {
        public int CourseStudyId { get; private set; }
        public int TestCount { get; private set; }
        public TimeSpan StudyTime { get; private set; }

        public int DailyStudyId { get; private set; }
        public int CourseId { get; private set; }
        public DailyStudy DailyStudy { get; private set; }
        public Course Course { get; private set; }
    }
}
