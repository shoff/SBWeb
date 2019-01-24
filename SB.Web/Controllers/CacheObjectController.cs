namespace SB.Web.Controllers
{
    using Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;


    [ApiController]
    [Route("api/[controller]")]
    public class CacheObjectController : ControllerBase
    {
        private readonly ILogger<RendersController> logger;
        private readonly ICacheObjectRepository cacheObjectRepository;

        public CacheObjectController(
            ILogger<RendersController> logger,
            ICacheObjectRepository cacheObjectRepository)
        {
            this.logger = logger;
            this.cacheObjectRepository = cacheObjectRepository;
        }
    }
}