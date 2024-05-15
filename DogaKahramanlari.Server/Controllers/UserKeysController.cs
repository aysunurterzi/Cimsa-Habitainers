using DogaKahramanlari.Server.Models;
using DogaKahramanlari.Server.Services.Contracts;
using DogaKahramanlari.Server.Utilities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DogaKahramanlari.Server.Controllers
{
    [ApiController]
    [Route("api/userKeys")]
    public class UserKeysController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly UserManager<User> _userManager;

        private User? _user;

        public UserKeysController(IServiceManager services, UserManager<User> userManager)
        {
            _services = services;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserKeysAsync()
        {
            return Ok(await _services
                .UserKeyService
                .GetAllUserKeysAsync(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUserKeyByIdAsync([FromRoute] string id)
        {
            return Ok(await _services
                .UserKeyService
                .GetOneUserKeyByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneUserKeyAsync([FromBody] UserKeyDtoForInsertion userkeyDto)
        {
            if (userkeyDto is null)
                return BadRequest(); // 400 

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var userKey = await _services.UserKeyService.CreateOneUserKeyAsync(userkeyDto);

            return StatusCode(201, userKey); // CreatedAtRoute()
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneUserKeyAsync([FromRoute(Name = "id")] string id,
                      [FromBody] UserKeyDtoForUpdate userkeyDto)
        {
            if (userkeyDto is null)
                return BadRequest(); // 400 

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.UserKeyService.UpdateOneUserKeyAsync(id, userkeyDto, false);
            return NoContent(); // 204
        }


    }
}