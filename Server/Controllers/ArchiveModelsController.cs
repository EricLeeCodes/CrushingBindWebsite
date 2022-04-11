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

        #region CRUD operations

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ArchiveModel> archiveModels = await _appDBContext.ArchiveModels.ToListAsync();

            return Ok(archiveModels);
        }

        //website.com/api/categories/withposts
        [HttpGet("withposts")]

        public async Task<IActionResult> GetWithPosts()
        {
            List<ArchiveModel> archiveModels = await _appDBContext.ArchiveModels
                .Include(archiveModel => archiveModel.Posts)
                .ToListAsync();

            return Ok(archiveModels);
        }

        //website.com/api/categories/2
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ArchiveModel archiveModel = await GetArchiveByArchiveId(id, false);

            return Ok(archiveModel);
        }

        //website.com/api/categories/withposts/2
        [HttpGet("withposts/{id}")]
        public async Task<IActionResult> GetWithPosts(int id)
        {
            ArchiveModel archiveModel = await GetArchiveByArchiveId(id, true);

            return Ok(archiveModel);
        }


        #endregion




        #region Utility methods

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<bool> PersistChangesToDatabase()
        {
            int amountOfChanges = await _appDBContext.SaveChangesAsync();

            return amountOfChanges > 0;
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<ArchiveModel> GetArchiveByArchiveId(int archiveId, bool withPosts)
        {

            ArchiveModel archiveToGet = null;

            if (withPosts == true)
            {
                archiveToGet = await _appDBContext.ArchiveModels
                    .Include(archive => archive.Posts)
                    .FirstAsync(archive => archive.ArchiveId == archiveId);
            }
            else
            {
                archiveToGet = await _appDBContext.ArchiveModels
                    .FirstAsync(archive => archive.ArchiveId == archiveId);
            }

            return archiveToGet;
        }

        #endregion



    }
}
