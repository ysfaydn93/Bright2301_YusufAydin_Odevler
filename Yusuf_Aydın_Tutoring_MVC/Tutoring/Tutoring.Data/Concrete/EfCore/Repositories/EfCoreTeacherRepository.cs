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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(TutoringContext _context) : base(_context)
        {

        }

        private TutoringContext Context
        {
            get { return _dbContext as TutoringContext; }
        }

        public async Task CreateWithUrl(Teacher teacher)
        {
            await Context.Teachers.AddAsync(teacher);
            await Context.SaveChangesAsync();
            teacher.Url = teacher.Url + "-" + teacher.Id;
            await Context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl, string lessonUrl)
        {

            var result = Context
                .Teachers
                .Where(p => p.IsActive && !p.IsDeleted)
                .Include(p => p.Lessons)
                .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(p => p.Lessons)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive)
        {
            var result = Context
                .Teachers
                .Where(i => i.IsDeleted == isDeleted)
                .AsQueryable();
            if (isActive != null)
            {
                result = result
                    .Where(i => i.IsActive == isActive)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<Teacher> GetTeachersByUrlAsync(string url)
        {
            var result = await Context
                .Teachers
                .Where(b => b.IsActive && !b.IsDeleted && b.Url == url)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Teacher>> GetTeachersWithFullDataAsync(bool? isActive)
        {
            var result = Context
                .Teachers
                .Where(b => !b.IsDeleted)
                .AsQueryable();

            if (isActive != null)
            {
                result = result
                    .Where(b => b.IsActive == isActive)
                    .AsQueryable();
            }
            result = result
                .Include(b => b.Lessons)
                .AsQueryable();

            return await result.ToListAsync();
        }
    }
}
