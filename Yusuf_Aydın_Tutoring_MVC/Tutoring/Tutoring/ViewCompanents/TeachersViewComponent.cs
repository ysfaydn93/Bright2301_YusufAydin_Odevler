using Tutoring.Business.Abstract;
using Tutoring.Business.Concrete;
using Tutoring.Entity.Concrete;
using Tutoring.Models;
using Microsoft.AspNetCore.Mvc;


namespace Tutoring.ViewComponents
{
    public class TeachersViewComponent : ViewComponent
    {
        private readonly ITeacherService _teacherManager;

        public TeachersViewComponent(ITeacherService teacherManager)
        {
            _teacherManager = teacherManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Teacher> teacherList = await _teacherManager.GetAllAsync();
            List<TeacherViewModel> teacherViewModelList = teacherList.Select(i => new TeacherViewModel
            {
                Name = i.FirstName + " " + i.LastName,
                Url = i.Url
            }).ToList();
            return View(teacherViewModelList);
        }
    }
}
