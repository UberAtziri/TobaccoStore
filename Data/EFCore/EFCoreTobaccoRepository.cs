using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TobaccoStore.Entities;

namespace TobaccoStore.Data.EFCore
{
    public class EFCoreTobaccoRepository : EFCoreRepository<TobaccoEntity, TobaccoContext>
    {
        private readonly TobaccoContext context;
        public EFCoreTobaccoRepository(TobaccoContext context) : base(context)
        {
         this.context = context;   
        }
        public IQueryable<string> GetName()
        {
            return context.Set<TobaccoEntity>().Select(i=>i.Title);
        }
    }
}