using Alorotbe.Api.Common;
using Core.Planing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Alorotbe.Api.Planning.Models
{
    public class DailtyStudyModel
    {
        public DailtyStudyModel()
        {}

        public DailtyStudyModel(DailyStudy study)
        {
            SelfEstimation = study.SelfEstimation;
            Mood = (byte)study.Mood;
            AwakeTime = study.AwakeTime.TimeString();
            StudyDate = HejriDate.Convert2Hejri(study.StudeyDate, "/");
            CourseStudies = study.CourseStudies.Select(c => new CourseStudyModel(c)).ToList();
        }

        public byte SelfEstimation { get; set; }
        public byte Mood { get; set; }
        public string AwakeTime { get; set; }
        public string StudyDate { get; set; }
        [JsonIgnore]
        public TimeSpan AwakeTimeSpan => TimeSpan.Parse(AwakeTime);
        public List<CourseStudyModel> CourseStudies { get; set;}
        private List<CourseStudy> Studies 
            => CourseStudies.Select(c => new CourseStudy(c.TestCount, c.StudyTimeSpan, c.CourseId)).ToList();
        internal DailyStudy DailyStudy(int studentId) => new DailyStudy(studentId, (Moods)Mood, SelfEstimation, AwakeTimeSpan, Studies);
    }
}
    