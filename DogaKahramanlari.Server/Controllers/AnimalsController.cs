using DogaKahramanlari.Server.Services.Contracts;
using DogaKahramanlari.Server.Utilities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace DogaKahramanlari.Server.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IServiceManager _services;
        public AnimalsController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAnimalsAsync()
        {
            return Ok(await _services
                .AnimalService
                .GetAllAnimalsAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllAnimalsAsync([FromRoute] int id)
        {
            return Ok(await _services
                .AnimalService
                .GetOneAnimalByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneAnimalAsync([FromBody] AnimalDtoForInsertion animalDto)
        {
            if (animalDto is null)
                return BadRequest(); // 400 

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var animal = await _services.AnimalService.CreateOneAnimalAsync(animalDto);

            return StatusCode(201, animal); // CreatedAtRoute()
        }

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> UpdateOneAnimalAsync([FromRoute(Name = "id")] int id,
        //    [FromBody] AnimalDtoForUpdate animalDto)
        //{
        //    if (animalDto is null)
        //        return BadRequest(); // 400 

        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);

        //    await _services.AnimalService.UpdateOneAnimalAsync(id, animalDto, false);
        //    return NoContent(); // 204
        //}

        [HttpPut("{id:int}")]
        
        public async Task<IActionResult> UpdateOneAnimalAsync([FromRoute(Name = "id")] int id,
            [FromBody] AnimalDtoForUpdate animalDto)
        {
            if (animalDto is null)
                return BadRequest(); // 400 

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.AnimalService.UpdateOneAnimalAsync(id, animalDto, false);
            return Ok(200); 
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneAnimalAsync([FromRoute(Name = "id")] int id)
        {
            await _services.AnimalService.DeleteOneAnimalAsync(id, false);
            return NoContent();
        }


    }
}
