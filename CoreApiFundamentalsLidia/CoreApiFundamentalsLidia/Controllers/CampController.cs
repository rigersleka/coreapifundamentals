using CoreApiFundamentalsLidia.DTOs;
using CoreApiFundamentalsLidia.Services;
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
        public void Add(CampDTO entity)
        {
            try
            {
                _campService.Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        [HttpDelete]
        public void Delete(CampDTO entity)
        {
            try
            {
                _campService.Delete(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<CampDTO>> GetAllCampAsync(bool includeTalks = false)
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
            }

            return models;

        }

        // do japi error ;) PO UN DO E BEJ :p
        [HttpGet("GetByDate")]
        public async Task<IEnumerable<CampDTO>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
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

            return models;
        }



    }
}
