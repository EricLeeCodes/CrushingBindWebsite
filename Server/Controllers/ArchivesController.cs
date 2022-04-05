using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArchivesController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public ArchivesController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Archive> archives = await _appDBContext.Archives.ToListAsync();

            return Ok(archives);
        }
    }
}
