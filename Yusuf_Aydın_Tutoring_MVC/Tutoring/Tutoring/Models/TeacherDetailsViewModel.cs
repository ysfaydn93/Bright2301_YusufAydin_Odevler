using System;
namespace Tutoring.Models
{
    public class TeacherDetailsViewModel
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
        public int EditionYear { get; set; }
        public int EditionNumber { get; set; }
        public int Stock { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
    }
}

