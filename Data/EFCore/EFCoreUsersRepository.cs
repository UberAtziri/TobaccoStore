using Microsoft.AspNetCore.Mvc;
using TobaccoStore.Entities;

namespace TobaccoStore.Data.EFCore
{
    public class EFCoreUsersRepository : EFCoreRepository<UserEntity, TobaccoContext>
    {
        public EFCoreUsersRepository(TobaccoContext context) : base(context)
        {
            
        }

        
    }
}