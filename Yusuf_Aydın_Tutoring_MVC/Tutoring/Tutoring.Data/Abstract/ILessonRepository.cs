using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Abstract
{
    public interface ILessonRepository: IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null);
        Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null);
        Task<Lesson> GetLessonByUrlAsync(string lessonUrl);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsWithTeacher(bool isDeleted);
        Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds);
        Task UpdateTeacherOfLessons();
        Task CheckLessonsCategories();
        void UpdateLesson(Lesson lesson);
    }
}








