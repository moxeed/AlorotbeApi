using Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Planing
{
    public class DailyStudy
    {
        private DailyStudy()
        {
        }

        public DailyStudy(int studentId, Moods mood, byte selfEstimation, TimeSpan awakeTime, List<CourseStudy> studies)
        {
            StudentId = studentId;
            Mood = mood;
            SelfEstimation = selfEstimation;
            AwakeTime = awakeTime;
            CourseStudies = studies;
            StudeyDate = DateTime.Now;
        }

        public int DailyStudyId { get; private set; }
        public byte SelfEstimation { get; private set; }
        public Moods Mood { get; private set; }
        public TimeSpan AwakeTime { get; private set; }
        public DateTime StudeyDate { get; private set;}

        public int StudentId { get; private set; }
        public Student Student { get; private set; }

        public ICollection<CourseStudy> CourseStudies { get; private set; }

        public TimeSpan TotalStudyTime => TimeSpan.FromMinutes(CourseStudies.Sum(s => s.StudyTime.Minutes));
        public int TotalTestCount => CourseStudies.Sum(c => c.TestCount);
        public int Score => TotalTestCount + TotalStudyTime.Minutes;
    }
}
