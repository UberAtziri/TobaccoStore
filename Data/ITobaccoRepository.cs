using System.Collections.Generic;
using System.Linq;
using TobaccoStore.Entities;

namespace TobaccoStore.Data
{
    public interface ITobaccoRepository
    {
        TobaccoEntity GetSingle(int id);
        void Add(TobaccoEntity item);
        TobaccoEntity Update(int id, TobaccoEntity item);
        List<TobaccoEntity> GetAll();
        int Count();
        bool Save();
        void Delete(int id);
        bool Exist(int id);

         
    }
}