using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository animal;

        public AnimalController(IAnimalRepository animal)
        {
            this.animal = animal;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetAll()
        {
            return Ok(animal.ListAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult GetById(int id)
        {
            try { return Ok(animal.GetAnimal(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Add([FromBody] Animal animal)
        {
            try { return Ok(this.animal.Add(animal)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.animal.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Update([FromBody] Animal animal)
        {
            try { return Ok(this.animal.Update(animal)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
