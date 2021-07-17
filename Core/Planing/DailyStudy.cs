using Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Planing
{
    public class DailyStudy
    {
        public int DailyStudyId { get; private set; }
        public byte SelfEstimation { get; private set; }
        public Moods Mood { get; private set; }
        public TimeSpan AwakeTime { get; private set; }

        public int StudentId { get; private set; }
        public Student Student { get; private set; }

        public ICollection<CourseStudy> CourseStudies { get; private set; }

        public TimeSpan TotalStudyTime => TimeSpan.FromMinutes(CourseStudies.Sum(s => s.StudyTime.TotalMinutes));
        public int TotalTestCount => CourseStudies.Sum(s => s.TestCount);
    }
}
