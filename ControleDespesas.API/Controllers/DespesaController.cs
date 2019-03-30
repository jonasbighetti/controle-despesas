using ControleDespesas.AppService.DTO;
using ControleDespesas.AppService.Interface;
using ControleDespesas.Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleDespesas.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Despesa")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaAppService _despesaAppService;

        public DespesaController(IDespesaAppService despesaAppService)
        {
            _despesaAppService = despesaAppService;
        }

        /// <summary>
        /// Cadastro de nova despesa
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Despesa), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] DespesaDTO input)
        {
            var obj = await _despesaAppService.AddAsync(input);
            return Created(nameof(Get), obj);
        }

        /// <summary>
        /// Buscar despesa por ID
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Despesa), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var obj = await _despesaAppService.GetByIdAsync(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        /// <summary>
        /// Buscar todas as despesas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Despesa), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _despesaAppService.GetAllAsync());
        }

        /// <summary>
        /// Editar uma despesa
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Despesa), 202)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Put([FromRoute]Guid id, [FromBody] DespesaDTO input)
        {
            var obj = _despesaAppService.GetByIdAsync(id);
            if (obj == null)
                return NotFound();

            return Accepted(await _despesaAppService.UpdateAsync(id, input));
        }

        /// <summary>
        /// Excluir uma despesa
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Despesa), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var obj = _despesaAppService.GetByIdAsync(id);
            if (obj == null)
                return NotFound();

            await _despesaAppService.DeleteAsync(id);

            return Ok();
        }
    }
}
