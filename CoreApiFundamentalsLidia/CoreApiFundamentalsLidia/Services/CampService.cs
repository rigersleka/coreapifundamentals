using AutoMapper;
using CoreApiFundamentalsLidia.AutoMapper;
using CoreApiFundamentalsLidia.Data;
using CoreApiFundamentalsLidia.Data.Entities;
using CoreApiFundamentalsLidia.DTOs;
using CoreApiFundamentalsLidia.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Services
{
    public class CampService : ICampService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CampService> _logger;
        private readonly ICampRepository _repository;

        public CampService(IMapper mapper, ILogger<CampService> logger, ICampRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task Add(CreateCampDTO entity)
        {
            try
            {
                var model = _mapper.Map<Camp>(entity);
                await _repository.Add(model);

                _logger.LogInformation(Messages.ADDED_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);

                if (entity == null || entity.Id == 0)
                {
                    throw new Exception("Camp object is null.");
                }
                await _repository.Delete(entity);

                _logger.LogInformation(Messages.DELETED_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;

            }
        }

        public async Task Update(CampDTO entity)
        {
            try
            {

                var camp = await _repository.GetById(entity.Id);
                if (camp == null)
                {
                    throw new Exception("Camp object is null.");
                }
                camp.Name = entity.Name;
                camp.Moniker = entity.Moniker;
                camp.EventDate = entity.EventDate;
                camp.Length = entity.Length;

                await _repository.UpdateCamp(camp);
                _logger.LogInformation(Messages.UPDATED_SUCCESFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        public async Task<IEnumerable<CampDTO>> GetAllCampsAsync(bool includeTalks = false)
        {
            var model = new List<CampDTO>();
            try
            {
                var camps = await _repository.GetAllCampsAsync();
                model = _mapper.Map<List<CampDTO>>(camps);
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return model;
        }

        public async Task<IEnumerable<CampDTO>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {
            var models = new List<CampDTO>();

            try
            {
                var camps = await _repository.GetAllCampsByEventDate(dateTime);
                models = _mapper.Map<List<CampDTO>>(camps);
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return models;
        }

        public async Task<CampDTO> GetCampAsync(string moniker, bool includeTalks = false)
        {
            var model = new CampDTO();

            try
            {
                var camps = await _repository.GetCampAsync(moniker);
                model = _mapper.Map<CampDTO>(camps);
                _logger.LogInformation(Messages.GET_SUCCESSFULLY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return model;
        }
    }
}
