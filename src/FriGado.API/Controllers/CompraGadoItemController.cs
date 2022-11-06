using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraGadoItemController : ControllerBase
    {
        private readonly ICompraGadoItemRepository compraGadoItem;

        public CompraGadoItemController(ICompraGadoItemRepository compraGadoItem)
        {
            this.compraGadoItem = compraGadoItem;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(compraGadoItem.ListAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try { return Ok(compraGadoItem.GetCompraGadoItem(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CompraGadoItem compraGadoItem)
        {
            try { return Ok(this.compraGadoItem.Add(compraGadoItem)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.compraGadoItem.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CompraGadoItem compraGadoItem)
        {
            try { return Ok(this.compraGadoItem.Update(compraGadoItem)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
