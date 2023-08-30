using AspNetCoreHero.ToastNotification.Abstractions;
using Tutoring.Business.Abstract;
using Tutoring.Business.Concrete;
using Tutoring.Core;
using Tutoring.Entity.Concrete;
using Tutoring.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tutoring.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherManager;
        private readonly INotyfService _notyf;

        public TeacherController(ITeacherService teacherManager, INotyfService notyf)
        {
            _teacherManager = teacherManager;
            _notyf = notyf;
        }

        #region Listeleme
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllTeachersAsync(false);
            List<TeacherViewModel> teacherViewModelList = teacherList
                .Select(a => new TeacherViewModel
                {
                    Id = a.Id,
                    Name = a.FirstName + " " + a.LastName,
                    CreatedDate = a.CreatedDate,
                    ModifiedDate = a.ModifiedDate,
                    About = a.About,
                    IsActive = a.IsActive,
                    Url = a.Url,
                    PhotoUrl = a.PhotoUrl,
                    BirthOfYear = a.BirthOfYear

                }).ToList();
            return View(teacherViewModelList);
        }
        #endregion
        #region Yeni Öğretmen
        [HttpGet]
        public IActionResult Create()
        {
            List<int> years = Jobs.GetYears(0, 2005);
            TeacherAddViewModel teacherAddViewModel = new TeacherAddViewModel
            {
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString()
                }).ToList()
            };
            return View(teacherAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddViewModel teacherAddViewModel)
        {
           if (ModelState.IsValid)
           {
               string name = teacherAddViewModel.FirstName + " " + teacherAddViewModel.LastName;
               Teacher teacher = new Teacher
               {
                   FirstName = teacherAddViewModel.FirstName,
                   LastName = teacherAddViewModel.LastName,
                   About = teacherAddViewModel.About,
                   IsActive = teacherAddViewModel.IsActive,
                   BirthOfYear = teacherAddViewModel.BirthOfYear,
                   Url = Jobs.GetUrl(name),
                   PhotoUrl = "default-profile.jpg"
                    

               };
               await _teacherManager.CreateWithUrl(teacher);
               _notyf.Success("Yazar kaydı başarıyla tamamlanmıştır.");
               return RedirectToAction("Index");
           }
            List<int> years = Jobs.GetYears(0, 2005);
            teacherAddViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString()
            }).ToList();
            return View(teacherAddViewModel);

        }

        #endregion
        #region Öğretmen Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var years = Jobs.GetYears(0, 2005);
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthOfYear = teacher.BirthOfYear,
                About = teacher.About,
                IsActive = teacher.IsActive,
                IsDeleted = teacher.IsDeleted,
                Url = teacher.Url,
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                    Selected = teacher.BirthOfYear == y ? true : false
                }).ToList()

            };

            return View(teacherEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEditViewModel teacherEditViewModel)
        {
           if (ModelState.IsValid)
           {
               Teacher teacher= await _teacherManager.GetByIdAsync(teacherEditViewModel.Id);
               if (teacher == null) { return NotFound(); }
               teacher.FirstName = teacherEditViewModel.FirstName;
               teacher.LastName = teacherEditViewModel.LastName;
               teacher.About = teacherEditViewModel.About;
               teacher.IsActive = teacherEditViewModel.IsActive;
               teacher.IsDeleted = teacherEditViewModel.IsDeleted;
               teacher.Url = teacherEditViewModel.Url;
               teacher.ModifiedDate = DateTime.Now;
               _teacherManager.Update(teacher);
               _notyf.Success("Öğretmen bilgisi başarıyla güncellenmiştir.", 2);
               return RedirectToAction("Index");
           }
            List<int> years = Jobs.GetYears(0, 2005);
            teacherEditViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString(),
                Selected = teacherEditViewModel.BirthOfYear == y ? true : false
            }).ToList();
            return View(teacherEditViewModel);

        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.IsActive = !teacher.IsActive;
            teacher.ModifiedDate = DateTime.Now;
            _teacherManager.Update(teacher);
            string isActive = teacher.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Yazar başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Öğretmen Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            TeacherDeleteViewModel teacherDeleteViewModel = new TeacherDeleteViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                About = teacher.About,
                Url = teacher.Url,
                IsActive = teacher.IsActive,
                IsDeleted = teacher.IsDeleted,
                IsAlive = teacher.IsDeleted,
                CreatedDate = teacher.CreatedDate,
                ModifiedDate = teacher.ModifiedDate
            };
            return View(teacherDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            _teacherManager.Delete(teacher);
            return RedirectToAction("Index");
        }
        #endregion
        #region Öğretmen Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Teacher teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.IsDeleted = true;
            teacher.ModifiedDate = DateTime.Now;
            _teacherManager.Update(teacher);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
