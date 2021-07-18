using System;
using Core.BasicInfo;

namespace Core.Planing
{
    public class CourseStudy
    {
        public CourseStudy()
        {

        }

        public CourseStudy(int testCount, TimeSpan studyTime, int courseId)
        {
            TestCount = testCount;
            StudyTime = studyTime;
            CourseId = courseId;
        }

        public int CourseStudyId { get; private set; }
        public int TestCount { get; private set; }
        public TimeSpan StudyTime { get; private set; }

        public int DailyStudyId { get; private set; }
        public int CourseId { get; private set; }
        public DailyStudy DailyStudy { get; private set; }
        public Course Course { get; private set; }
    }
}
