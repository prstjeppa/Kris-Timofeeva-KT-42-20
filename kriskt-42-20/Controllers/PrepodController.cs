using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kriskt_42_20.Filters.PrepodFilters;
using kriskt_42_20.Interfaces.PrepodInterfaces;

namespace kriskt_42_20.Controllers
{
    [ApiController]
    [Route("contoller")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService)
        {
            _logger = logger;
            _prepodService = prepodService;
        }

        [HttpPost(Name = "GetPrepodsByGroup")]
        public async Task<IActionResult> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByGroupAsync(filter, cancellationToken);

            return Ok(prepod);
        }
    }
}
