using AspNetCoreHero.ToastNotification.Abstractions;
using Tutoring.Business.Abstract;
using Tutoring.Core;
using Tutoring.Entity.Concrete;
using Tutoring.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


namespace Tutoring.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonManager;
        private readonly ITeacherService _teacherManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public LessonController(ILessonService lessonManager, ITeacherService teacherManager, ICategoryService categoryManager, INotyfService notyf)
        {
            _lessonManager = lessonManager;
            _teacherManager = teacherManager;
            _categoryManager = categoryManager;
            _notyf = notyf;
        }

        #region Listeleme
        public async Task<IActionResult> Index()
        {
            List<Lesson> lessons = await _lessonManager.GetAllLessonsWithTeacher(false);
            List<LessonViewModel> lessonViewModelList = lessons
                .Select(b => new LessonViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    TeacherName = b.Teacher.FirstName + " " + b.Teacher.LastName,
                }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        #endregion
        #region Yardımcı Metotlar(Action Olmayanlar)
        [NonAction]
        private async Task<List<SelectListItem>> GetTeacherSelectList()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllTeachersAsync(false, true);
            List<SelectListItem> teacherViewModelList = teacherList.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            return teacherViewModelList;
        }

        [NonAction]
        private async Task<List<CategoryViewModel>> GetCategoryList()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false, true);
            List<CategoryViewModel> categoryViewModelList = categoryList.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return categoryViewModelList;
        }

        [NonAction]
        private List<SelectListItem> GetYearList(int startYear, int endYear)
        {
            List<int> years = Jobs.GetYears(startYear, endYear);
            List<SelectListItem> yearList = years.Select(y => new SelectListItem
            {
                Value = y.ToString(),
                Text = y.ToString()
            }).ToList();
            return yearList;
        }
        #endregion
        #region Yeni Kitap
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacherViewModelList = await GetTeacherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            LessonAddViewModel lessonAddViewModel = new LessonAddViewModel
            {
                TeacherList = teacherViewModelList,
                CategoryList = categoryViewModelList,
                YearList = yearList
            };
            return View(lessonAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {
            if (ModelState.IsValid && lessonAddViewModel.SelectedCategoryIds.Count > 0)
            {
                var url = Jobs.GetUrl(lessonAddViewModel.Name);
                Lesson lesson = new Lesson
                {
                    Name = lessonAddViewModel.Name,
                    Description = lessonAddViewModel.Description,
                    IsActive = lessonAddViewModel.IsActive,
                    IsHome = lessonAddViewModel.IsHome,
                    ModifiedDate = DateTime.Now,
                    TeacherId = lessonAddViewModel.TeacherId,
                    Price = lessonAddViewModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(lessonAddViewModel.ImageFile, url, "lessons")
                };
                await _lessonManager.CreateLessonAsync(lesson, lessonAddViewModel.SelectedCategoryIds);
                _notyf.Success("Kayıt işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            if (lessonAddViewModel.SelectedCategoryIds.Count == 0)
            {
                ViewBag.CategoryErrorMessage = "En az bir kategori seçilmelidir.";
            }
            var teacherViewModelList = await GetTeacherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonAddViewModel.TeacherList = teacherViewModelList;
            lessonAddViewModel.CategoryList = categoryViewModelList;
            lessonAddViewModel.YearList = yearList;
            return View(lessonAddViewModel);
        }

        #endregion
        #region Kitap Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                _notyf.Warning("Sadece aktif ve silinmemiş kitaplar düzenlenebilir.");
                return RedirectToAction("Index");
            }
            LessonEditViewModel lessonEditViewModel = new LessonEditViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                TeacherId = lesson.TeacherId,
                ImageUrl = lesson.ImageUrl,
                IsActive = lesson.IsActive,
                IsDeleted = lesson.IsDeleted,
                IsHome = lesson.IsHome,
                Price = lesson.Price,
                SelectedCategoryIds = lesson.LessonCategories.Select(bc => bc.CategoryId).ToList(),
                TeacherList = await GetTeacherSelectList(),
                CategoryList = await GetCategoryList(),
                YearList = GetYearList(1900, DateTime.Now.Year)
            };
            return View(lessonEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LessonEditViewModel lessonEditViewModel)
        {
            if (ModelState.IsValid && lessonEditViewModel.SelectedCategoryIds.Count() > 0)
            {
                Lesson lesson = new Lesson();
                var url = Jobs.GetUrl(lessonEditViewModel.Name);
                lesson.Id = lessonEditViewModel.Id;
                lesson.Name = lessonEditViewModel.Name;
                lesson.Description = lessonEditViewModel.Description;
                lesson.Price = lessonEditViewModel.Price;
                lesson.IsActive = lessonEditViewModel.IsActive;
                lesson.IsHome = lessonEditViewModel.IsHome;
                lesson.IsDeleted = lessonEditViewModel.IsDeleted;
                //Lesson.TeacherId = LessonEditViewModel.TeacherId;
                lesson.Url = url;

                lesson.LessonCategories = lessonEditViewModel.SelectedCategoryIds.Select(sc => new LessonCategory
                {
                    LessonId = lesson.Id,
                    CategoryId = sc
                }).ToList();
                lesson.ImageUrl = lessonEditViewModel.ImageFile == null ? lessonEditViewModel.ImageUrl : Jobs.UploadImage(lessonEditViewModel.ImageFile, url, "lessons");
                _lessonManager.UpdateLesson(lesson);
                _notyf.Success("Güncelleme işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            var teacherViewModelList = await GetTeacherSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            lessonEditViewModel.TeacherList = teacherViewModelList;
            lessonEditViewModel.CategoryList = categoryViewModelList;
            lessonEditViewModel.YearList = yearList;
            return View(lessonEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            lesson.IsActive = !lesson.IsActive;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string isActive = lesson.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Kitap başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Kitap Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Lesson lesson = await _lessonManager.GetLessonByIdAsync(id);
            if (lesson == null) return NotFound();
            LessonDeleteViewModel lessonDeleteViewModel = new LessonDeleteViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                TeacherName = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName,
                Price = lesson.Price,
                IsActive = lesson.IsActive,
                IsHome = lesson.IsHome
            };
            return View(lessonDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _lessonManager.Delete(lesson);
            return RedirectToAction("Index");
        }
        #endregion"
        #region Kitap Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Lesson lesson = await _lessonManager.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            lesson.IsDeleted = !lesson.IsDeleted;
            lesson.ModifiedDate = DateTime.Now;
            _lessonManager.Update(lesson);
            string message = lesson.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return lesson.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Silinmiş Kitap Listeleme
        public async Task<IActionResult> DeletedIndex()
        {
            List<Lesson> lessons = await _lessonManager.GetAllLessonsWithTeacher(true);
            List<LessonViewModel> lessonViewModelList = lessons
                .Select(b => new LessonViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    TeacherName = b.Teacher.FirstName + " " + b.Teacher.LastName,
                }).ToList();
            LessonListViewModel model = new LessonListViewModel
            {
                LessonViewModelList = lessonViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }

        #endregion

    }
}
