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
        private readonly IWebHostEnvironment _webHostEvnironment;

        public ArchiveModelsController(AppDBContext appDBContext, IWebHostEnvironment webHostEvnironment)
        {
            _appDBContext = appDBContext;
            _webHostEvnironment = webHostEvnironment;
        }



        #region GET

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

        #region POST

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArchiveModel archiveToCreate)
        {
            try
            {
                if (archiveToCreate == null)
                {
                    return BadRequest(ModelState);
                }           

                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                //Does the actual creating
                await _appDBContext.ArchiveModels.AddAsync(archiveToCreate);

                bool changesPersistedToDatabase = await PersistChangesToDatabase();

                if (changesPersistedToDatabase == false)
                {
                    return StatusCode(500, $"Something went wrong on our side. Please contact the administrator.");
                }
                else
                {
                    return Created("Create", archiveToCreate);
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. " +
                    $"Error message: {e.Message}.");
            }
        }

        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArchiveModel updatedArchiveModel)
        {
            try
            {
                if (id < 1 || updatedArchiveModel == null || id != updatedArchiveModel.ArchiveId)
                {
                    return BadRequest(ModelState);
                }

                bool exists = await _appDBContext.ArchiveModels.AnyAsync(archiveModel => archiveModel.ArchiveId == id);

                if (exists == false)
                {
                    return NotFound();
                }

                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                _appDBContext.ArchiveModels.Update(updatedArchiveModel);

                bool changesPersistedToDatabase = await PersistChangesToDatabase();

                if (changesPersistedToDatabase == false)
                {
                    return StatusCode(500, $"Something went wrong on our side. Please contact the administrator.");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. " +
                    $"Error message: {e.Message}.");
            }
        }
        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest(ModelState);
                }

                bool exists = await _appDBContext.ArchiveModels.AnyAsync(archiveModel => archiveModel.ArchiveId == id);

                if (exists == false)
                {
                    return NotFound();
                }

                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                ArchiveModel archiveToDelete = await GetArchiveByArchiveId(id, false);

                if (archiveToDelete.ArchiveThumbnailImagePath != "uploads/placeholder.jpg")
                {
                    string fileName = archiveToDelete.ArchiveThumbnailImagePath.Split('/').Last();

                    System.IO.File.Delete($"{_webHostEvnironment.ContentRootPath}\\wwwroot\\uploads\\{fileName}");
                }

                _appDBContext.ArchiveModels.Remove(archiveToDelete);

                bool changesPersistedToDatabase = await PersistChangesToDatabase();

                if (changesPersistedToDatabase == false)
                {
                    return StatusCode(500, $"Something went wrong on our side. Please contact the administrator.");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. " +
                    $"Error message: {e.Message}.");
            }
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
