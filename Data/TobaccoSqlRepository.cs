using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobaccoStore.Data;
using TobaccoStore.Entities;

namespace TobaccoStore.Data
{
    public class TobaccoSqlRepository :ITobaccoRepository
    {
        private readonly TobaccoContext _tobaccoContext;
        public TobaccoSqlRepository(TobaccoContext tobaccoContext)
        {
            _tobaccoContext = tobaccoContext;
        }

        public TobaccoEntity GetSingle(int id)
        {
            return _tobaccoContext.Tobacco.FirstOrDefault(x => x.Id == id);
        }

        public void Add (TobaccoEntity item)
        {
            _tobaccoContext.Tobacco.Add(item);
        }

        public void Delete (int id)
        {
            TobaccoEntity tobaccoItem = GetSingle(id);
            _tobaccoContext.Tobacco.Remove(tobaccoItem);
        }

        public TobaccoEntity Update (int id, TobaccoEntity item)
        {
            _tobaccoContext.Tobacco.Update(item);
            return item;
        }

        public List<TobaccoEntity> GetAll()
        {
            return _tobaccoContext.Tobacco.ToList();
        }

        public int Count()
        {
            return _tobaccoContext.Tobacco.Count();
        }

        public bool Save()
        {
            return (_tobaccoContext.SaveChanges() >= 0);
        }

        public bool Exist(int id)
        {
            return _tobaccoContext.Tobacco.Any(i=>i.Id==id);
        }


    }
}
