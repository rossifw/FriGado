using FriGado.API.Domain;
using FriGado.API.Repository;
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
        public IActionResult GetAll()
        {
            return Ok(animal.ListAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try { return Ok(animal.GetAnimal(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Animal animal)
        {
            try { return Ok(this.animal.Add(animal)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try { return Ok(this.animal.Remove(id)); }
            catch { return new StatusCodeResult(204); }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Animal animal)
        {
            try { return Ok(this.animal.Update(animal)); }
            catch { return new StatusCodeResult(204); }
        }
    }
}
