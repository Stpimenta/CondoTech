using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CCondominium : ControllerBase
    {
        private readonly CondominiumService _condominiumService;
        public CCondominium( CondominiumService condominiumService)
        {
            _condominiumService = condominiumService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CondominiumModel> condominiums = await _condominiumService.GetAllAsync();
            return Ok(condominiums);
        }

        [HttpPost]
        public async Task<IActionResult> AddCondominium([FromBody] CondominiumDtos.CreateCondominiumDto condominium)
        {   
            //automatic validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            throw new Exception("vai merda");
            int id = await _condominiumService.Addasync(condominium);
            return Ok(new{ id });
        }
    }
}