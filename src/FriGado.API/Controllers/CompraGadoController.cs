using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraGadoController : ControllerBase
    {
        private readonly ICompraGadoRepository compraGado;

        public CompraGadoController(ICompraGadoRepository compraGado)
        {
            this.compraGado = compraGado;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(compraGado.ListAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try { return Ok(compraGado.GetCompraGado(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CompraGado compraGado)
        {
            try { return Ok(this.compraGado.Add(compraGado)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.compraGado.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CompraGado compraGado)
        {
            try { return Ok(this.compraGado.Update(compraGado)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
