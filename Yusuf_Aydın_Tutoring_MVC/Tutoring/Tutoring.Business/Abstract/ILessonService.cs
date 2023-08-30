using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Business.Abstract
{
    public interface ILessonService
    {
        
        Task<Lesson> GetByIdAsync(int id);
        Task<List<Lesson>> GetAllAsync();
        Task CreateAsync(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(Lesson lesson);

        Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null);
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null);
        Task<Lesson> GetLessonByUrlAsync(string teacherUrl);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsWithTeacher(bool isDeleted);
        Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds);
        Task UpdateTeacherOfLessons();
        Task CheckLessonsCategories();
        void UpdateLesson(Lesson lesson);
    }
}
