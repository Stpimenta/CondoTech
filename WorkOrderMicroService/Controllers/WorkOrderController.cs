using MicroServiceWorkOrder.Application.Dtos;
using MicroServiceWorkOrder.Application.Services;
using MicroServiceWorkOrder.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWorkOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WorkOrderController : ControllerBase
    {
        private readonly  WorkOrderService _workOrderService;
        public WorkOrderController( WorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<WorkOrderModel> workOrders = await _workOrderService.GetAllAsync();
            return Ok(workOrders);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            WorkOrderModel workOrderModel = await _workOrderService.GetById(id);
            return Ok(workOrderModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkOrder([FromBody]  WorkOrderDto.CreateAndGetWorkOrder workOrderDto)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            int id = await _workOrderService.Addasync(workOrderDto);
            return Ok(new{ id });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkOrder(int id, [FromBody] WorkOrderDto.CreateAndGetWorkOrder workerOrderDto)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _workOrderService.UpdateAsync(id,workerOrderDto);
            return Ok(new{ id });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _workOrderService.DeleteById(id);
            return Ok();
        }
    }
}