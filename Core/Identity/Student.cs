using Alorotbe.Core.BasicInfo;
using Alorotbe.Core.Identity;
using Core.BasicInfo;
using System;

namespace Core.Identity
{
    public class Student
    {
        public int StudentId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int? AvgLevel { get; private set; }
        public decimal? GPA { get; private set; }
        public bool HasSupporter { get; private set; }

        public int? CityId { get; private set; }
        public int GradeId { get; private set;}
        public int MajorId { get; private set;}
        public int UserId { get; private set; }
        public int? SuppporterId { get; private set; }
        public int? MediaId { get; private set; }
        public City City { get; private set; }
        public Grade Grade { get; private set; }
        public Major Major { get; private set; }
        public User User { get; private set; }
        public Supporter Supporter { get; set; }
        public Media Profile { get; set;}

        public Student() { }

        public Student(string name, string lastName, int? avgLevel, decimal? gPA, bool hasSupporter, int cityId, int majorId, int gradeId, int? suppporterId)
        {
            Name = name;
            LastName = lastName;
            AvgLevel = avgLevel;
            GPA = gPA;
            HasSupporter = hasSupporter;
            CityId = cityId;
            GradeId = gradeId;
            MajorId = majorId;
            SuppporterId = suppporterId;
        }

        public void SetUserId(int userId)
        {
            if (UserId != default) 
            {
                throw new InvalidOperationException("Student Already Have a User Id");
            }
            UserId = userId;
        }
    }
}
