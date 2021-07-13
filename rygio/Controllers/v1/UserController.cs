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
using rygio.Command.v1.Dtos.Request;
using rygio.Helper;
using static rygio.Command.v1.RevokeTokenCommand;

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
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> signin([FromBody] AuthDto dto)
        {
            try
            {
                LoginCommand request = new LoginCommand { authDto = dto };
                var result = await mediator.Send(request);


                return Ok(new { data = result });

            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
        }

        /// <summary>
        /// register a new account with email and phone number
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup([FromBody] UserRegisterationDto dto)
        {
            try
            {
                RegisterCommand request = new RegisterCommand { registerDto=dto};
                var result = await mediator.Send(request);

                
                    return Ok(new { message = result, IsSuccess = true });
               
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
        }

        /// <summary>
        /// Signin with google
        /// </summary>
        /// <remarks>
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
        /// Signup with google
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("google_signup")]
        public async Task<IActionResult> googleSignup([FromBody] ExternalAuthDto dto)
        {
            try
            {
                GoogleRegisterCommand request = new GoogleRegisterCommand
                {
                    googleAuthDto = dto
                };
                var result = await mediator.Send(request);
                return Ok(new { message = result });

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
                return Ok(new { data= result });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Signup with facebook
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("facebook_signup")]
        public async Task<IActionResult> facebookSignup([FromBody] ExternalAuthDto dto)
        {
            try
            {
                FacebookRegisterCommand request = new FacebookRegisterCommand
                {
                    facebookAuthDto = dto
                };
                var result = await mediator.Send(request);
                return Ok(new { message = result });

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
        /// refresh access token
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("refresh_token")]
        public async Task<IActionResult> refreshToken([FromBody] RefreshTokenDto token)
        {
            try
            {
                RefreshTokenCommand request = new RefreshTokenCommand { token = token.RefreshToken };
                var result = await mediator.Send(request);
                return Ok(new { data = result });

            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
        }

        /// <summary>
        /// revoke token
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("revoke_refresh_token")]
        public async Task<IActionResult> revokeRefreshToken([FromBody] RefreshTokenDto token)
        {
            try
            {
                RevokeTokenCommand request = new RevokeTokenCommand { token = token.RefreshToken };
                var result = await mediator.Send(request);
                return Ok(new { message = result });

            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
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
        [HttpGet]
        [Route("logged_in_user")]
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
