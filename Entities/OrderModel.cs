using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.OData.Builder;

namespace TobaccoStore.Entities
{
    public class OrderModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int? TobaccoId { get; set; }
        [ForeignKey("TobaccoId")]
        [AutoExpand]
        public List<TobaccoEntity> Purchases { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [AutoExpand]
        public User Customer{get; set;}
        

    }
}