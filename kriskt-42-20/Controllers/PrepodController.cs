using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kriskt_42_20.Filters.PrepodKafedraFilters;
using kriskt_42_20.Interfaces.PrepodInterfaces;

namespace kriskt_42_20.Controllers
{
    [ApiController]
    [Route("prepod")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService)
        {
            _logger = logger;
            _prepodService = prepodService;
        }

        [HttpPost(Name = "GetPrepodsByKafedra")]
        public async Task<IActionResult> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByKafedraAsync(filter, cancellationToken);

            return Ok(prepod);
        }

    }
}
