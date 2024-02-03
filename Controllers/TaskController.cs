using ApiCrudTasks.Models;
using ApiCrudTasks.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> FindAllTasks()
        {

            List<TaskModel> tasks = await _taskRepository.FindAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindTaskById(int id)
        {

            TaskModel task = await _taskRepository.FindTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> IInsertTask([FromBody] TaskModel taskModel)
        {

            TaskModel task = await _taskRepository.InsertTask(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {

            TaskModel updateTask = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(updateTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {

            bool delete = await _taskRepository.DeleteTask(id);
            return Ok(delete);
        }
    }
}
