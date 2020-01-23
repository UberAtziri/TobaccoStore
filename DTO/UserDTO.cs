using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.OData.Builder;
using TobaccoStore.Entities;

namespace TobaccoStore.DTO
{
    public class UserDTO
    {
       [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        [AutoExpand]
        public RoleEntity Role { get; set; } 
    }
}