using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraGadoController : ControllerBase
    {
        private readonly ICompraGadoRepository<CompraGado> compraGado;

        public CompraGadoController(ICompraGadoRepository<CompraGado> compraGado)
        {
            this.compraGado = compraGado;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            return Ok(compraGado.ListAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult GetById(int id)
        {
            try { return Ok(compraGado.Get(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Add([FromBody] CompraGado compraGado)
        {
            try { return Ok(this.compraGado.Add(compraGado)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.compraGado.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Update([FromBody] CompraGado compraGado)
        {
            try { return Ok(this.compraGado.Update(compraGado)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
