using DataModel.Models;

namespace MedUnifyUI.Services
{
    public interface ILoginService
    {

        public Task<string> LoginAsync(LoginModel loginModel);
    }
}
