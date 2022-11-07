using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraGadoItemController : ControllerBase
    {
        private readonly ICompraGadoItemRepository<CompraGadoItem> compraGadoItem;

        public CompraGadoItemController(ICompraGadoItemRepository<CompraGadoItem> compraGadoItem)
        {
            this.compraGadoItem = compraGadoItem;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            return Ok(compraGadoItem.ListAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult GetById(int id)
        {
            try { return Ok(compraGadoItem.Get(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CompraGadoItem compraGadoItem)
        {
            try { return Ok(this.compraGadoItem.Add(compraGadoItem)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.compraGadoItem.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Update([FromBody] CompraGadoItem compraGadoItem)
        {
            try { return Ok(this.compraGadoItem.Update(compraGadoItem)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
