using Alorotbe.Api.Common;
using Core.Planing;
using System;
using System.Text.Json.Serialization;

namespace Alorotbe.Api.Planning.Models
{
    public class CourseStudyModel
    {
        public CourseStudyModel()
        {}

        public CourseStudyModel(CourseStudy courseStudy)
        {
            TestCount = courseStudy.TestCount;
            StudyTime = courseStudy.StudyTime.TimeString();
            CourseId = courseStudy.CourseId;
            CourseName = courseStudy.Course.CourseName;
        }

        public int TestCount { get; set; }
        public string StudyTime { get; set; }
        [JsonIgnore]
        public TimeSpan StudyTimeSpan => TimeSpan.Parse(StudyTime);
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}