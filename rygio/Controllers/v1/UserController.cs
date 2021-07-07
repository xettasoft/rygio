using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rygio.Command;
using rygio.Command.v1;

namespace rygio.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger;
        }

        /// <summary>
        /// Signin with username(Email or Phone) and password
        /// </summary>
        /// <remarks>
        /// <h3>Type is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : BUYING</li>
        /// <li>2 : DELIVERY</li>
        /// <li>3 : BOTH</li>
        /// </ul>
        /// <h3>Status is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Deactivated</li>
        /// <li>2 : Activated</li>
        /// <li>3 : Pending</li>
        /// <li>4 : Suspended</li> 
        /// </ul>
        /// <h3>DocumentReviewStatus is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Denied</li>
        /// <li>2 : Accepted</li>
        /// <li>3 : Processing</li>
        /// </ul>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> signin()
        {
            try
            {
                //var result = await mediator.Send(request);

               
                    return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// register a new account with email and phone number
        /// </summary>
        /// <remarks>
        /// <h3>Type is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : BUYING</li>
        /// <li>2 : DELIVERY</li>
        /// <li>3 : BOTH</li>
        /// </ul>
        /// <h3>Status is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Deactivated</li>
        /// <li>2 : Activated</li>
        /// <li>3 : Pending</li>
        /// <li>4 : Suspended</li> 
        /// </ul>
        /// <h3>DocumentReviewStatus is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Denied</li>
        /// <li>2 : Accepted</li>
        /// <li>3 : Processing</li>
        /// </ul>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Signin with google
        /// </summary>
        /// <remarks>
        /// <h3>Type is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : BUYING</li>
        /// <li>2 : DELIVERY</li>
        /// <li>3 : BOTH</li>
        /// </ul>
        /// <h3>Status is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Deactivated</li>
        /// <li>2 : Activated</li>
        /// <li>3 : Pending</li>
        /// <li>4 : Suspended</li> 
        /// </ul>
        /// <h3>DocumentReviewStatus is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Denied</li>
        /// <li>2 : Accepted</li>
        /// <li>3 : Processing</li>
        /// </ul>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("google_signin")]
        public async Task<IActionResult> googleSignin([FromBody] ExternalAuthDto dto)
        {
            try
            {


                GoogleAuthenticationCommand request = new GoogleAuthenticationCommand
                {
                    googleAuthDto = dto
                };
                var result = await mediator.Send(request);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Signin with facebook
        /// </summary>
        /// <remarks>
        /// <h3>Type is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : BUYING</li>
        /// <li>2 : DELIVERY</li>
        /// <li>3 : BOTH</li>
        /// </ul>
        /// <h3>Status is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Deactivated</li>
        /// <li>2 : Activated</li>
        /// <li>3 : Pending</li>
        /// <li>4 : Suspended</li> 
        /// </ul>
        /// <h3>DocumentReviewStatus is an Enum with the following value</h3>
        /// <ul>
        /// <li>1 : Denied</li>
        /// <li>2 : Accepted</li>
        /// <li>3 : Processing</li>
        /// </ul>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("facebook_signin")]
        public async Task<IActionResult> facebookSignin([FromBody] ExternalAuthDto dto)
        {
            try
            {


                FacebookAuthCommand request = new FacebookAuthCommand
                {
                    facebookAuthDto = dto
                };
                var result = await mediator.Send(request);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Signup with google, facebook or twitter
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("external_signup")]
        public async Task<IActionResult> externalSignup()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// upload photo
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("upload_photo")]
        public async Task<IActionResult> photo()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("password_reset")]
        public async Task<IActionResult> reset()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// change password
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("change_password")]
        public async Task<IActionResult> change()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// financial history
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> history()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// edit user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> edit()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// logged-in user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> single()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// all user users
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> allUsers()
        {
            try
            {
                //var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
