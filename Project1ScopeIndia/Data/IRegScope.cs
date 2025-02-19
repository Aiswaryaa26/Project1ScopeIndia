using Project1ScopeIndia.Models;

namespace Project1ScopeIndia.Data
{
    public interface IRegScope
    {
        void Insert(RegistrationModel regScope);
        void Update(RegistrationModel regScope);
        RegistrationModel GetById(int Id);
        RegistrationModel GetByEmail(String RegEmailAddress);
        List<RegistrationModel> GetAll();
    }
}
