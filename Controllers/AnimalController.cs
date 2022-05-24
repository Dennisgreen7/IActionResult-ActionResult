using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public List<Animal> Animals = new List<Animal> { new Animal { Id = 1, Name = "Dog" }, new Animal { Id = 2, Name = "Cat" }, new Animal { Id = 3, Name = "Lion" }, new Animal { Id = 4, Name = "Zebra" }, new Animal { Id = 5, Name = "Giraffe" } };
        [Route("{name}")]
        public IActionResult GetAnimalByName(string name)
        {
            if (name == "Giraffe")
            {
                return LocalRedirect("~/api/Animal/smile");
            }
            foreach (Animal animal in this.Animals)
            {
                if (animal.Name == name)
                {
                    return Ok(animal);
                }
            }
            return NotFound();
        }
        [Route("special/{name}")]
        public ActionResult<Animal> GetAnimalByName2(string name)
        {
            if (name == "Giraffe")
            {
                return LocalRedirect("~/api/Animal/smile");
            }
            foreach (Animal animal in this.Animals)
            {
                if (animal.Name == name)
                {
                    return animal;
                }
            }
            return NotFound();
        }
        [Route("smile")]
        public string Smile()
        {
            return "=)";
        }
    }
}
