using Tutoring.Business.Abstract;
using Tutoring.Business.Concrete;
using Tutoring.Entity.Concrete;
using Tutoring.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Tutoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonService _productManager;

        public HomeController(ICategoryService categoryManager, ILessonService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Lesson> productList = await _productManager.GetLessonsWithFullDataAsync(true, true);
            List<LessonViewModel> productViewModelList = productList.Select(p => new LessonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Url = p.Url,
                ImageUrl = p.ImageUrl,
                TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                TeacherUrl = p.Teacher.Url,
            }).ToList();
            return View(productViewModelList);
        }
    }
}