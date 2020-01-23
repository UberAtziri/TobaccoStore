using TobaccoStore.Entities;

namespace TobaccoStore.Data.EFCore
{
    public class EFCoreRoleRepository : EFCoreRepository<RoleEntity, TobaccoContext>
    {
        public EFCoreRoleRepository(TobaccoContext context) : base(context)
        {
            
        }
    }
}