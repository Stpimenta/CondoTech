using Microsoft.AspNetCore.Mvc;
using WorkerMicroService.Application.Dtos;
using WorkerMicroService.Application.Services;
using WorkerMicroService.Domain.Models;

namespace WorkerMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WorkerController : ControllerBase
    {
        private readonly  WorkerService _workerService;
        public WorkerController( WorkerService workerService)
        {
            _workerService = workerService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<WorkerModel> condominiums = await _workerService.GetAllAsync();
            return Ok(condominiums);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            WorkerModel condominiums = await _workerService.GetById(id);
            return Ok(condominiums);
        }

        [HttpPost]
        public async Task<IActionResult> AddCondominium([FromBody] WorkerDtos.CreateAndGetWorker worker)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            int id = await _workerService.Addasync(worker);
            return Ok(new{ id });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCondominium(int id, [FromBody] WorkerDtos.CreateAndGetWorker worker)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _workerService.UpdateAsync(id,worker);
            return Ok(new{ id });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _workerService.DeleteById(id);
            return Ok();
        }
    }
}