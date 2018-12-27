namespace SB.Web.Controllers
{
    using System.Threading.Tasks;
    using Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class RendersController : ControllerBase
    {
        private readonly ILogger<RendersController> logger;
        private readonly IRendersRepository rendersRepository;

        public RendersController(
            ILogger<RendersController> logger,
            IRendersRepository rendersRepository)
        {
            this.logger = logger;
            this.rendersRepository = rendersRepository;
        }


        [HttpGet]
        [Route("dupes")]
        public async Task<IActionResult> Get()
        {
            var renders = await this.rendersRepository.GetRendersCount();
            return this.Ok(renders);
        }

        [HttpGet]
        [Route("{page}/{count}")]
        public async Task<IActionResult> Get(int page, int count)
        {
            var renders = await this.rendersRepository.GetPagedRenderInformationAsync(page, count);
            return this.Ok(renders);
        }
    }
}