using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rygio.Command.v1.RegionCommands;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Query.v1.RegionQuery;
using rygio.Query.v1.RegionQuery.Dtos.Request;
using System;
using System.Threading.Tasks;

namespace rygio.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IMediator mediator;

        public RegionController(ILogger<RegionController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create a region
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> create([FromBody] NewRegionDto dto)
        {
            try
            {
                int user =int.Parse( User.Identity.Name);
                CreateCommand request = new CreateCommand { RegionDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result});

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
        }

        /// <summary>
        /// edit a region
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPatch]
        [Route("edit")]
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
        /// get a single Region
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
        /// get nearest Region
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> getAll([FromQuery] NearestRegionDto dto)
        {
            try
            {
                NearestQuery request = new NearestQuery {pageParameter = dto };
                var result = await mediator.Send(request);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// region thumbsup
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("thumbsup")]
        public async Task<IActionResult> thumbsup()
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
        /// region thumbsdown
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("thumbsdown")]
        public async Task<IActionResult> thumbsdown()
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
        /// delete a region
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
    }
}
