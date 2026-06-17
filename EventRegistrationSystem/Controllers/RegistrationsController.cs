using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateRegistrationRequest request)
        {
            var result = await _registrationService.RegisterUserForEventAsync(request);
            if (!result) return BadRequest("Registration failed. Event may be full or does not exist.");
            return Ok(new
            {
                message = "Registration successful"
            });
        }
        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetRegistrationsByUserId(int userId)
        {
            var registrations = await _registrationService.GetRegistrationsByUserIdAsync(userId);
            return Ok(registrations);
        }
        [HttpDelete("{registrationId}")]
        public async Task<IActionResult> Delete(int registrationId)
        {
            var result = await _registrationService.CancelRegistrationAsync(registrationId);
            if (!result) return NotFound();
            return Ok(new
            {
                message = "Registration deleted successfully"
            });
        }
}
}
