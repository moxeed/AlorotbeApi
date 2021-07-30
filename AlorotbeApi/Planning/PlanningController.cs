﻿using Alorotbe.Api.Common;
using Alorotbe.Api.Planning.Models;
using Alorotbe.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alorotbe.Api.Planning
{
    public class PlanningController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PlanningController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Submit()
        {
            if (!StudentId.HasValue)
                return BadRequest("Faild");

            var isSubmited = await _context.DailyStudies.AnyAsync(d => d.StudeyDate.Date == DateTime.Now.Date && d.StudentId == StudentId);
            return Ok(isSubmited);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Submit(DailtyStudyModel model)
        {
            if (!StudentId.HasValue)
                return BadRequest("Faild");

            var isSubmited = await _context.DailyStudies.AnyAsync(d => d.StudeyDate.Date == DateTime.Now.Date && d.StudentId == StudentId);

            if (isSubmited)
                return BadRequest("گزارش امروز ثبت شده است");

            try {
                var study = model.DailyStudy(StudentId.Value);
                _context.Add(study);

                await _context.SaveChangesAsync();
                return Ok(new SuccessRespnose());
            }
            catch(Exception e) {
                return BadRequest(new ErrorResponse{ Error = "Invalid Data"});
            }
        }

        [HttpGet]
        public async Task<IActionResult> Rank()
        {
            var studentScore = _context.StudentScores.FirstOrDefault(s => s.UserId == UserId);

            if (studentScore is null)
                return Ok(new RankModel());

            var sameGrades = _context.StudentScores.Where(d => d.MajorId == studentScore.MajorId 
            && d.GradeId == studentScore.GradeId);

            var testRank = await _context.StudentScores.CountAsync(d => d.TotalTestCount > studentScore.TotalTestCount) + 1;
            var timeRank = await _context.StudentScores.CountAsync(d => d.TotalStudy > studentScore.TotalStudy) + 1; 
            var scoreRank = await _context.StudentScores.CountAsync(d => d.Score > studentScore.Score) + 1; 
            
            return Ok(new RankModel 
            {
                TestRank = testRank,
                TimeRank = testRank,
                ScoreRank = scoreRank
            });
        }

        [HttpGet]
        public async Task<IActionResult> Top([FromQuery] TopFilterModel model)
        {
            var data = _context.StudentScores.FromSqlRaw("GetTopStudent @p0, @p1, @p2, @p3", model.Period, model.Criterion, model.Count, model.GradeId);
            var scores = await data.ToListAsync();
            return Ok(scores.Select(s => new StudentScoreModel(s)));
        }

        [HttpGet("{count?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Study(int? count) 
        {
            count ??= int.MaxValue;
            var studies = await _context.DailyStudies
                .Include(d => d.CourseStudies)
                .ThenInclude(c => c.Course)
                .Where(d => d.StudentId == StudentId)
                .OrderByDescending(d => d.StudeyDate)
                .Take(count.Value).ToListAsync();

            return Ok(studies.Select(s => new DailtyStudyModel(s)));
        }

        [HttpGet("{period?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Progress(int Period)
        {
            var startDate = DateTime.Now.AddDays(-Period);

            var studies = await _context.DailyStudies
                .Include(s => s.CourseStudies)
                .Where(d => d.StudentId == StudentId
                && d.StudeyDate > startDate).ToListAsync();

            var progress = new List<ProgressModel>();

            for(int i = 0; i < Period; i++)
            {
                var date = startDate.AddDays(i);
                var study = studies.FirstOrDefault(s => s.StudeyDate.Date == date.Date);
                if (study is null)
                    progress.Add(new ProgressModel{ Date = HejriDate.NullAbleDatetimeToHejri(date)});
                else
                    progress.Add(new ProgressModel
                    {
                        Date = HejriDate.NullAbleDatetimeToHejri(date),
                        TestCount = study.TotalTestCount,
                        StudyMinute = study.TotalStudyTime.Minutes
                    });
            }

            return Ok(progress);
        }
    }
}
