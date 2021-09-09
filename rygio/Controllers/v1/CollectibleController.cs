using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rygio.Command.v1.CollectibleCommand;
using rygio.Command.v1.CollectibleCommand.Dtos;
using rygio.Query.v1.CollectibleQuery;
using rygio.Query.v1.CollectibleQuery.RequestDto;
using System;
using System.Threading.Tasks;

namespace rygio.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CollectibleController : ControllerBase
    {
        private readonly ILogger<CollectibleController> _logger;

        private readonly IMediator mediator;
        public CollectibleController(ILogger<CollectibleController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create a collectible template
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> create([FromBody] CreateDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                CreateCommand request = new CreateCommand { CreateDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Mint a collectible
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("mint")]
        public async Task<IActionResult> minted([FromBody] MintDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                MintCommand request = new MintCommand { MintDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// transfer a collectible
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> transfer([FromBody] TransferDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                TransferCommand request = new TransferCommand { TransferDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result });

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
        public async Task<IActionResult> getSingle([FromQuery] int collectible)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                SingleQuery request = new SingleQuery { Collectible = collectible, User = user };
                var result = await mediator.Send(request);
                return Ok(new { data = result});

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
        public async Task<IActionResult> getAll([FromQuery] UserQueryDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                UserQuery request = new UserQuery { pageParameter = dto, User=user };
                var result = await mediator.Send(request);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

/*        /// <summary>
        /// get all collectible trails
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("trails")]
        public async Task<IActionResult> trails()
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

        /// <summary>
        /// edit Collectible template
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
        /// delete a collectible template
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        
        public async Task<IActionResult> delete([FromBody] DeleteDto dto)
        {
            try
            {
                int user = int.Parse(User.Identity.Name);
                DeleteCommand request = new DeleteCommand { DeleteDto = dto, User = user };
                var result = await mediator.Send(request);


                return Ok(new { message = result });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
