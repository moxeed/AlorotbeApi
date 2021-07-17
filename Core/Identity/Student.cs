﻿using Core.BasicInfo;
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

        public int CityId { get; private set; }
        public int GroupId { get; private set; }
        public int UserId { get; private set; }
        public int? SuppporterId { get; private set; }
        public City City { get; private set; }
        public Group Group { get; private set; }
        public User User { get; private set; }
        public Supporter Supporter { get; set; }

        public Student() { }

        public Student(string name, string lastName, int? avgLevel, decimal? gPA, bool hasSupporter, int cityId, int groupId, int? suppporterId)
        {
            Name = name;
            LastName = lastName;
            AvgLevel = avgLevel;
            GPA = gPA;
            HasSupporter = hasSupporter;
            CityId = cityId;
            GroupId = groupId;
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