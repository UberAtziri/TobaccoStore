using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.OData.Builder;
using TobaccoStore.Data;

namespace TobaccoStore.Entities
{
    public class UserEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { 
            get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        [AutoExpand]
        public RoleEntity UserRole { get; set; }
    }
    
}
