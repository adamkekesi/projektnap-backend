using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface ITeacherService
    {
        public List<TeacherModel> GetAll();
    }
}
