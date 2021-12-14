using CoreApiFundamentalsLidia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Data
{
    public interface ICampRepository
    {
        void Add(Camp entity);
        void Delete(Camp entity);
        Task<IEnumerable<Camp>> GetAllCampsAsync(bool includeTalks = false);
        Task<Camp> GetCampAsync(string moniker, bool includeTalks = false);
        Task<IEnumerable<Camp>> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);
    }
}
