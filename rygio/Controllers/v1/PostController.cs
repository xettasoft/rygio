using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rygio.Command.v1.PostCommands;
using rygio.Command.v1.PostCommands.Dtos;
using System;
using System.Threading.Tasks;

namespace rygio.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator mediator;

        public PostController(ILogger<PostController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /*/// <summary>
        /// make a post (location based or regional)
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] MakePostDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                CreateCommand request = new() { PostDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// delete a post
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]

        public async Task<IActionResult> delete()
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
        /// make a comment
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> comment()
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
        /// reply a comment
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("reply")]
        public async Task<IActionResult> reply()
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
        /// like a post,comment or reply
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> like()
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
        /// get a single collectible
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> getSingle()
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
        /// get all user collectibles
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> getAll()
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
        /// add a member
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("member")]
        public async Task<IActionResult> member()
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
        /// delete a member
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("member")]
        public async Task<IActionResult> deleteMember()
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
        }*/
    }
}
