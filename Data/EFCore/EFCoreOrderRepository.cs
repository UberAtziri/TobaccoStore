using TobaccoStore.Entities;

namespace TobaccoStore.Data.EFCore
{
    public class EFCoreOrderRepository : EFCoreRepository<OrderEntity, TobaccoContext>
    {
        public EFCoreOrderRepository(TobaccoContext context) : base(context)
        {
            
        }
    }
}