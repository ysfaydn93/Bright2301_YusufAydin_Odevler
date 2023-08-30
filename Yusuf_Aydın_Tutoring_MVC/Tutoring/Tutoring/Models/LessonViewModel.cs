namespace Tutoring.Models
{
	public class LessonViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public DateTime Time { get; set; }
		public string TeacherName { get; set; }
		public string TeacherUrl { get; set; }
	}
}
