using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rygio.Query.v1;
using System;
using System.Threading.Tasks;

namespace rygio.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {
        private readonly ILogger<InstanceController> _logger;
        private readonly IMediator mediator;
        public InstanceController(ILogger<InstanceController> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger;
        }

        /// <summary>
        /// Fetch current location collectibles
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("new")]
        public async Task<IActionResult> fetch()
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
        /// pick or drop notification
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("pick_drop_notification")]
        public async Task<IActionResult> picknDropNotifier()
        {
            try
            {
                PicknDropNotifierQuery request = new PicknDropNotifierQuery { group = ""};
                   var result = await mediator.Send(request);


                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }



        /// <summary>
        /// get all collectibles in store
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("store")]
        public async Task<IActionResult> store()
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
