using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class TeacherService:ITeacherService
    {
    private readonly DataContext _dataContext;
    private readonly GenericService<TeacherModel> _genericServices;

    public TeacherService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _genericServices = new(dataContext, httpContextAccessor);
    }
        public List<TeacherModel> GetAll()
        {
            return _genericServices.ReadAll().ToList();
        }
    }
}
