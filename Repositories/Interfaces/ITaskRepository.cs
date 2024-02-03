using ApiCrudTasks.Models;

namespace ApiCrudTasks.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> FindAllTasks();
        Task<TaskModel> FindTaskById(int id);
        Task<TaskModel> InsertTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<Boolean> DeleteTask(int id);
    }
}
