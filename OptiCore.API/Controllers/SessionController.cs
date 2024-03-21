using Auth.Core;
using Auth.Core.Interfaces;
using Auth.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace OptiCore.API.Controllers
{
    [Route("api/session")]
    [ApiController]
    [Authorize]
    public class SessionController : Controller
    {
        private IAuthorizationServerInteractor _authorizationServerInteractor;
        public SessionController(IAuthorizationServerInteractor authorizationServerInteractor)
        {
            _authorizationServerInteractor = authorizationServerInteractor;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("google/start")]
        public async Task<IActionResult> StartSession()
        {
            try
            {
                var authHeaderValue = Request.Headers.Authorization.ToString() ?? "bearer test";
                var idToken = authHeaderValue.Split(" ")[1];
                var sessionInfo = await _authorizationServerInteractor.CreateUserSessionAsync(idToken);
                if (sessionInfo == null)
                {
                    return BadRequest("Could not start session.");
                }
                Response.Cookies.Append(Constants.Cookies.Session, sessionInfo.SessionGuid, new CookieOptions { HttpOnly = true });
                return Ok("Session started");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> EndSession()
        {
            try
            {
                await _authorizationServerInteractor.EndUserSessionAsync();
                Response.Cookies.Delete(Constants.Cookies.Session);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}