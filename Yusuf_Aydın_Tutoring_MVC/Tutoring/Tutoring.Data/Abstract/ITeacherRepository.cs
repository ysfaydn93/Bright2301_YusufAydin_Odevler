using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersAsync(bool isDeleted, bool? isActive);
        Task CreateWithUrl(Teacher teacher);
        Task<List<Teacher>> GetAllActiveTeachersAsync(string categoryUrl, string lessonUrl);
        Task<Teacher> GetTeachersByUrlAsync(string url);
        Task<List<Teacher>> GetTeachersWithFullDataAsync(bool? isActive);
    }
}
