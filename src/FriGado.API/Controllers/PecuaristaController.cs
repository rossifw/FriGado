using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecuaristaController : ControllerBase
    {
        private readonly IPecuaristaRepository pecuarista;

        public PecuaristaController(IPecuaristaRepository pecuarista)
        {
            this.pecuarista = pecuarista;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(pecuarista.ListAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try { return Ok(pecuarista.GetPecuarista(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Pecuarista pecuarista)
        {
            try { return Ok(this.pecuarista.Add(pecuarista)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.pecuarista.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Pecuarista pecuarista)
        {
            try { return Ok(this.pecuarista.Update(pecuarista)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
