using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArchiveModelsController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public ArchiveModelsController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ArchiveModel> archiveModels = await _appDBContext.ArchiveModels.ToListAsync();

            return Ok(archiveModels);
        }
    }
}
