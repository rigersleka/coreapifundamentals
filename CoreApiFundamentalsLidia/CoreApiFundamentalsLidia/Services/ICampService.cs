using CoreApiFundamentalsLidia.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Services
{
    public interface ICampService
    {
        Task Add(CreateCampDTO entity);
        Task Delete(int id);
        Task Update(CampDTO entity);
        Task<IEnumerable<CampDTO>> GetAllCampsAsync(bool includeTalks = false);
        Task<CampDTO> GetCampAsync(string moniker, bool includeTalks = false);
        Task<IEnumerable<CampDTO>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);
    }
}
