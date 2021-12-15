using CoreApiFundamentalsLidia.DTOs;
using CoreApiFundamentalsLidia.Services;
using CoreApiFundamentalsLidia.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApiFundamentalsLidia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampController : ControllerBase
    {

        private readonly ICampService _campService;
        private readonly ILogger<CampController> _logger;

        public CampController(ICampService campService, ILogger<CampController> logger)
        {
            _campService = campService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateCampDTO entity)
        {
            try
            {
                await _campService.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _campService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampDTO>>> GetAllCampAsync(bool includeTalks = false)
        {
            var models = new List<CampDTO>();
            try
            {
                var listofCamps = await _campService.GetAllCampsAsync(includeTalks);
                models = listofCamps.ToList();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Not Found");
            }

            return Ok(models);

        }

        [HttpGet("GetByDate")]
        public async Task<ActionResult<IEnumerable<CampDTO>>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {
            var models = new List<CampDTO>();

            try
            {
                var listOfCampsByDate = await _campService.GetAllCampsByEventDate(dateTime, includeTalks);
                models = listOfCampsByDate.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(models);
        }

        // PUT: /camp/update
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCamp([FromBody] CampDTO entity)
        {

            try
            {
                // get campById
                await _campService.Update(entity);

                return Ok(new { message = Messages.UPDATED_SUCCESFULLY });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}
