using Tutoring.Business.Abstract;
using Tutoring.Business.Concrete;
using Tutoring.Entity.Concrete;
using Tutoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tutoring.MVC.Controllers
{
    public class TutoringController : Controller
    {
        private readonly ILessonService _lessonManager;
        private readonly ITeacherService _teacherManager;

        public TutoringController(ILessonService lessonManager, ITeacherService teacherManager)
        {
            _lessonManager = lessonManager;
            _teacherManager = teacherManager;
        }

        public async Task<IActionResult> LessonList(string categoryurl = null, string teacherurl = null)
        {
            List<Lesson> lessonList = await _lessonManager.GetAllActiveLessonsAsync(categoryurl, teacherurl);
            List<LessonViewModel> lessonViewModelList = lessonList.Select(p => new LessonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Url = p.Url,
                ImageUrl = p.ImageUrl,
                TeacherName = p.Teacher.FirstName + " " + p.Teacher.LastName,
                TeacherUrl = p.Teacher.Url,
            }).ToList();
            return View(lessonViewModelList);
        }
        public async Task<IActionResult> LessonDetails(string url)
        {
            Lesson lesson = await _lessonManager.GetLessonByUrlAsync(url);
            LessonDetailsViewModel lessonDetailsViewModel = new LessonDetailsViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                TeacherName = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName,
                TeacherAbout = lesson.Teacher.About,
                TeacherUrl = lesson.Teacher.Url,
                Url = lesson.Url,
                ImageUrl = lesson.ImageUrl,
                Description = lesson.Description,
                Price = lesson.Price,
                Categories = lesson.LessonCategories.Select(bc => new CategoryViewModel
                {
                    Name = bc.Category.Name,
                    Url = bc.Category.Url
                }).ToList()
            };
            return View(lessonDetailsViewModel);
        }
        public async Task<IActionResult> TeacherList(string categoryurl = null, string teacherurl = null)
        {
            List<Teacher> teacherList = await _teacherManager.GetAllActiveTeachersAsync(categoryurl, teacherurl);
            List<TeacherViewModel> teacherViewModelList = teacherList.Select(p => new TeacherViewModel
            {
                Id = p.Id,
                Name = p.FirstName + " " + p.LastName,
                Url = p.Url,
                ImageUrl = p.PhotoUrl
            }).ToList();
            return View(teacherViewModelList);
        }
        public async Task<IActionResult> TeacherDetails(string url)
        {
            Teacher teacher = await _teacherManager.GetTeachersByUrlAsync(url);
            TeacherDetailsViewModel teacherDetailsViewModel = new TeacherDetailsViewModel
            {
                Id = teacher.Id,
                TeacherName = teacher.FirstName + " " + teacher.LastName,
                TeacherAbout = teacher.About,
                TeacherUrl = teacher.Url,
                Url = teacher.Url,
                ImageUrl = teacher.PhotoUrl
            };
            return View(teacherDetailsViewModel);
        }
    }
}
