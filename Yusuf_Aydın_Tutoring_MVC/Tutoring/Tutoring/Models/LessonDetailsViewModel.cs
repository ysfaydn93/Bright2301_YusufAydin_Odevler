using System;
namespace Tutoring.Models
{
    public class LessonDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAbout { get; set; }
        public string TeacherUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public string Description { get; set; }
    }
}

