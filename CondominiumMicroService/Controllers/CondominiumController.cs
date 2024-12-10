using CondominiumMicroService.Application.Dtos;
using CondominiumMicroService.Domain;
using Microsoft.AspNetCore.Mvc;
using CondominiumMicroService.Application.Services;

namespace CondominiumMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CondominiumController : ControllerBase
    {
        private readonly Application.Services.CondominiumService _condominiumService;
        public CondominiumController( Application.Services.CondominiumService condominiumService)
        {
            _condominiumService = condominiumService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CondominiumModel> condominiums = await _condominiumService.GetAllAsync();
            return Ok(condominiums);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CondominiumModel condominiums = await _condominiumService.GetById(id);
            return Ok(condominiums);
        }

        [HttpPost]
        public async Task<IActionResult> AddCondominium([FromBody] CondominiumDtos.CreateAndGetCondominiumDto condominium)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            int id = await _condominiumService.Addasync(condominium);
            return Ok(new{ id });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCondominium(int id, [FromBody] CondominiumDtos.CreateAndGetCondominiumDto condominium)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _condominiumService.UpdateAsync(id,condominium);
            return Ok(new{ id });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _condominiumService.DeleteById(id);
            return Ok();
        }
    }
}