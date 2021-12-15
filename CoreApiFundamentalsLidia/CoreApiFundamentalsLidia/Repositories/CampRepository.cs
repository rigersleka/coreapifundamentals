using CoreApiFundamentalsLidia.Data.Entities;
using CoreApiFundamentalsLidia.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Data
{
    public class CampRepository : ICampRepository
    {
        private readonly CampContext _context;
        private readonly ILogger<CampRepository> _logger;

        public CampRepository(CampContext context, ILogger<CampRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add(Camp entity)
        {
            try
            {
                _logger.LogInformation(Messages.ADDED_SUCCESSFULLY);
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task Delete(Camp entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation(Messages.DELETED_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        public async Task UpdateCamp(Camp entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation(Messages.UPDATED_SUCCESFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<IEnumerable<Camp>> GetAllCampsAsync(bool includeTalks = false)
        {
            var models = new List<Camp>();

            try
            {
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);
                models = await _context.Camps.OrderByDescending(c => c.EventDate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return models;
        }

        public async Task<IEnumerable<Camp>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {

            List<Camp> models = new List<Camp>();

            try
            {
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);

                models = await _context.Camps
                     .OrderByDescending(c => c.EventDate)
                     .Where(c => c.EventDate.Date == dateTime.Date).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return models;
        }

        public async Task<Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {
            var model = new Camp();

            try
            {
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);

                model = await _context.Camps
                     .Where(c => c.Moniker == moniker)
                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return model;
        }
        public async Task<Camp> GetById(int id)
        {
            var model = new Camp();

            try
            {
                model = await _context.Camps
                       .Where(c => c.Id == id)
                       .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return model;
        }


    }
}
