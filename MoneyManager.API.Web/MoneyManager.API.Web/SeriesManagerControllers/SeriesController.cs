using Microsoft.AspNetCore.Mvc;
using MoneyManager.API.Data.SeriesManagerData;
using MoneyManager.API.Data.Services.SeriesManagerDataContext;
using MoneyManager.API.Data.Services.SeriesManagerServices;
using System.Collections.Generic;

namespace SeriesManager.API.Web.SeriesManagerControllers
{
    /// <summary>
    /// Controller for calling expense operations
    /// </summary>
    [Produces("application/json")]
    [Route("api/MoneyManager/Series/")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private SeriesService seriesService;
        public SeriesController(SeriesManagerContext seriesManagerContext)
        {
            seriesService = new SeriesService(seriesManagerContext);
        }

        /// <summary>
        /// Add expense details to database through service
        /// </summary>
        /// <param name="Series">Data from clientside</param>
        /// <returns>No content or error</returns>
        [HttpPost]
        [Route("AddSeries")]
        public IActionResult AddSeries(Series expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            seriesService.AddSeries(expense);
            return NoContent();
        }

        /// <summary>
        /// Gets list of expense details from database through service
        /// </summary>
        /// <returns>List of expense details</returns>
        [HttpGet]
        [Route("GetSeries")]
        public IEnumerable<Series> GetSeries()
        {
            return seriesService.GetSeries();
        }

        /// <summary>
        /// Delete series
        /// </summary>
        /// <returns>List of expense details</returns>
        [HttpDelete]
        [Route("DeleteSeries/{seriesId}")]
        public bool DeleteSeries([FromRoute]long seriesId)
        {
            return seriesService.DeleteSeries(seriesId);
        }
    }
}
