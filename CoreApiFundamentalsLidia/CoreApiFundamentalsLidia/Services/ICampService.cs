using CoreApiFundamentalsLidia.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Services
{
    public interface ICampService
    {
        void Add(CampDTO entity);
        void Delete(CampDTO entity);
        Task<IEnumerable<CampDTO>> GetAllCampsAsync(bool includeTalks = false);
        Task<CampDTO> GetCampAsync(string moniker, bool includeTalks = false);
        Task<IEnumerable<CampDTO>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);
    }
}
