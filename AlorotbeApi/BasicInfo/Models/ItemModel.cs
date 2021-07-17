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

        public ItemModel(Group group)
        {
            Id = group.GroupId;
            Name = group.GroupName;
        }

        public ItemModel(City city) 
        {
            Id = city.CityId;
            Name = city.CityName;
        }
    }
}
