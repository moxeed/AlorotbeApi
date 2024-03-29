﻿using Alorotbe.Persistence.Planning.Views;
using System;

namespace Alorotbe.Api.Planning.Models
{
    public class StudentScoreModel
    {
        public string UserName { get; }
        public int? ProfileId { get; }
        public string LastName { get; }
        public string MajorName { get; }
        public string GardeName { get; }
        public string TotalStudy { get; }
        public int TotalTestCount { get; }
        public int Score { get; }

        public StudentScoreModel(StudentScore score)
        {
            UserName = score.UserName;
            MajorName = score.MajorName;
            GardeName = score.GradeName;
            TotalTestCount = score.TotalTestCount;
            var timeSpan = TimeSpan.FromMinutes(score.TotalStudy);
            TotalStudy = GetTimeString(timeSpan);
            Score = score.Score;
            ProfileId = score.ProfileId;
        }

        private string GetTimeString(TimeSpan timeSpan) => 
            (timeSpan.Days > 0 ? timeSpan.Days + "روز و " : "") +
            $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}";
    }
}
