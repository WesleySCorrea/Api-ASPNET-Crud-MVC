using ApiCrudTasks.Data;
using ApiCrudTasks.Models;
using ApiCrudTasks.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiCrudTasks.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SystemTasksDBContext _dbContext;

        public TaskRepository(SystemTasksDBContext context) 
        {
            _dbContext = context;
        }

        public async Task<List<TaskModel>> FindAllTasks()
        {
            return await _dbContext.Tasks
                .Include(task =>  task.User)
                .ToListAsync();
        }

        public async Task<TaskModel> FindTaskById(int id)
        {
            return await _dbContext.Tasks
                .Include(task => task.User)
                .FirstOrDefaultAsync(task => task.Id == id);
        }
        public async Task<TaskModel> InsertTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await this.FindTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task with Id: {id} don't exist");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserID = task.UserID;

            _dbContext.Tasks.Update(taskById);
            _dbContext.SaveChanges();

            return taskById;
        }
        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await this.FindTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task with Id: {id} don't exist");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
