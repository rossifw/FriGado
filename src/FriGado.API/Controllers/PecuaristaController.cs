using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            return Ok(pecuarista.ListAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult GetById(int id)
        {
            try { return Ok(pecuarista.GetPecuarista(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Add([FromBody] Pecuarista pecuarista)
        {
            try { return Ok(this.pecuarista.Add(pecuarista)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.pecuarista.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Update([FromBody] Pecuarista pecuarista)
        {
            try { return Ok(this.pecuarista.Update(pecuarista)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
