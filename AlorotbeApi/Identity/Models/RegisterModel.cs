﻿using Core.Identity;
using System.ComponentModel.DataAnnotations;

namespace Alorotbe.Api.Identity.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int? AvgLevel { get; set; }
        public decimal? GPA { get; set; }
        [Required]
        public bool? HasSupporter { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public int? GradeId { get; set; }
        [Required]
        public int? MajorId { get; set; }
        public int? SupporterId { get; set; }
        public string SupporterName { get; set; }

        internal Student Student => new(Name, LastName, AvgLevel, GPA, HasSupporter.Value, CityId.Value, MajorId.Value, GradeId.Value, SupporterName, SupporterId);
    }
}
