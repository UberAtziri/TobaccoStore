using TobaccoStore.Data;

namespace TobaccoStore.Entities
{
    public class RoleEntity : IEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}