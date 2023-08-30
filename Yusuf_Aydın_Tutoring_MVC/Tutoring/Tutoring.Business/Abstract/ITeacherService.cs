using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);

        Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Teacher teacher);
        Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl = null, string teacherUrl = null);
        Task<Teacher> GetTeachersByUrlAsync(string teacherUrl);
        Task<List<Teacher>> GetTeachersWithFullDataAsync(bool? isActive = null);
    }
}
