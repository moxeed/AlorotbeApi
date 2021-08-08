using Alorotbe.Core.BasicInfo;
using Core.BasicInfo;

namespace Alorotbe.Api.BasicInfo.Models
{
    public class ItemModel
    {
        public int Id { get; }
        public string Name { get; }

        public ItemModel(Course course)
        {
            Id = course.CourseId;
            Name = course.CourseName;
        }
        public ItemModel(State state)
        {
            Id = state.StateId;
            Name = state.StateName;
        }

        public ItemModel(Major major)
        {
            Id = major.MajorId;
            Name = major.MajorName;
        }

        public ItemModel(Grade grade)
        {
            Id = grade.GradeId;
            Name = grade.GradeName;
        }

        public ItemModel(City city) 
        {
            Id = city.CityId;
            Name = city.CityName;
        }
    }
}
