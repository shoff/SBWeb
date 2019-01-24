namespace SB.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Extensions;
    using Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ViewModels;

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
            var views = renders.Map(r => new RenderViewModel
            {
                CompressedSize = r.CompressedSize,
                Data = r.Data.ToHexString(" "),
                Identity = r.Identity,
                Junk1 = r.Junk1,
                Name = r.Name,
                Offset = r.Offset,
                Order = r.Order,
                RenderRawId = r.RenderRawId,
                UnCompressedSize = r.UnCompressedSize
            }).ToList();
            return this.Ok(views);
        }
    }
}