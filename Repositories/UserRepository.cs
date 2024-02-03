using ApiCrudTasks.Data;
using ApiCrudTasks.Models;
using ApiCrudTasks.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiCrudTasks.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemTasksDBContext _dbContext;

        public UserRepository(SystemTasksDBContext context) 
        {
            _dbContext = context;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<UserModel> InsertUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await this.FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User with Id: {id} don't exist");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            _dbContext.SaveChanges();

            return userById;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await this.FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User with Id: {id} don't exist");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
