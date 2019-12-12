namespace ErrorCenter.Application.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser(string email, string password, string name);

        bool Login(string email, string password);
    }
}
