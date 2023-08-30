using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Data.Abstract;
using Tutoring.Data.Concrete.EfCore.Contexts;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Concrete.EfCore.Repositories
{
    public class EfCoreLessonRepository: EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(TutoringContext _context) : base(_context)
        {

        }

        private TutoringContext Context
        {
            get { return _dbContext as TutoringContext; }
        }

        public async Task CheckLessonsCategories()
        {
            var lessonCategoryIds = await Context
                .LessonCategories
                .Select(bc => bc.LessonId)
                .Distinct()
                .ToListAsync();
            var lessonIds = await Context
                .Lessons
                .Select(b => b.Id)
                .ToListAsync();
            List<int> different = lessonIds.Except(lessonCategoryIds).ToList();
            await Context.LessonCategories.AddRangeAsync(different.Select(d => new LessonCategory
            {
                LessonId = d,
                CategoryId = 1
            }).ToList());
            await Context.SaveChangesAsync();
        }

        public async Task CreateLessonAsync(Lesson lesson, List<int> SelectedCategoryIds)
        {
            await Context.Lessons.AddAsync(lesson);
            await Context.SaveChangesAsync();
            lesson.LessonCategories = SelectedCategoryIds.Select(sc => new LessonCategory
            {
                LessonId = lesson.Id,
                CategoryId = sc
            }).ToList();
            Context.Lessons.Update(lesson);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetAllActiveLessonsAsync(string categoryUrl = null, string teacherUrl = null)
        {
            var result = Context
                .Lessons
                .Where(b => b.IsActive && !b.IsDeleted)
                .Include(b => b.Teacher)
                .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(b => b.LessonCategories)
                    .ThenInclude(bc => bc.Category)
                    .Where(b => b.LessonCategories.Any(bc => bc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (teacherUrl != null)
            {
                result = result
                    .Where(b => b.Teacher.Url == teacherUrl)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<List<Lesson>> GetAllLessonsWithTeacher(bool isDeleted)
        {
            var result = await Context
                .Lessons
                .Where(b => b.IsDeleted == isDeleted)
                .Include(b => b.Teacher)
                .ToListAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var result = await Context
                .Lessons
                .Where(b => b.IsActive && !b.IsDeleted && b.Id == id)
                .Include(b => b.LessonCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Teacher)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Lesson> GetLessonByUrlAsync(string lessonUrl)
        {
            var result = await Context
                .Lessons
                .Where(b => b.IsActive && !b.IsDeleted && b.Url == lessonUrl)
                .Include(b => b.LessonCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Teacher)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Lesson>> GetLessonsWithFullDataAsync(bool? isHome = null, bool? isActive = null)
        {
            var result = Context
                .Lessons
                .Where(b => !b.IsDeleted)
                .AsQueryable();

            if (isActive != null)
            {
                result = result
                    .Where(b => b.IsActive == isActive)
                    .AsQueryable();
            }
            result = result
                .Include(b => b.LessonCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Teacher)
                .AsQueryable();
            return await result.ToListAsync();
        }

        public async Task UpdateTeacherOfLessons()
        {
            var lessons = await Context
                .Lessons
                .ToListAsync();
            foreach (var lesson in lessons)
            {
                lesson.TeacherId = 1;
            };
            Context.Lessons.UpdateRange(lessons);
            await Context.SaveChangesAsync();
        }

        public void UpdateLesson(Lesson lesson)
        {
            Lesson book = Context
                .Lessons
                .Include(b => b.LessonCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Teacher)
                .Where(b => b.Id == lesson.Id)
                .FirstOrDefault();
            book.Name = lesson.Name;
            book.Description = lesson.Description;
            book.Price = lesson.Price;
            book.IsActive = lesson.IsActive;
            book.IsDeleted = lesson.IsDeleted;
            book.TeacherId = lesson.TeacherId;
            book.Url = lesson.Url;
            book.ModifiedDate = DateTime.Now;
            book.LessonCategories = lesson.LessonCategories;
            book.ImageUrl = lesson.ImageUrl;

            Context.Lessons.Update(book);
            Context.SaveChanges();
        }
    }
}
