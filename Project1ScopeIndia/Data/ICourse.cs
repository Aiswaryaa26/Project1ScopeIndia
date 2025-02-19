using Project1ScopeIndia.Models;

namespace Project1ScopeIndia.Data
{
    public interface ICourse
    {
       CourseModel GetById(int CourseId);
       
       List<CourseModel> GetAll();
    }
}
