using ApiCrudTasks.Models;

namespace ApiCrudTasks.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindUserById(int id);
        Task<UserModel> InsertUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<Boolean> DeleteUser(int id);
    }
}
