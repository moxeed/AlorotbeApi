using System;
using System.Text.Json.Serialization;

namespace Alorotbe.Api.Planning.Models
{
    public class CourseStudyModel
    {
        public int TestCount { get; set; }
        public string StudyTime { get; set; }
        [JsonIgnore]
        public TimeSpan StudyTimeSpan => TimeSpan.Parse(StudyTime);
        public int CourseId { get; set; }
    }
}