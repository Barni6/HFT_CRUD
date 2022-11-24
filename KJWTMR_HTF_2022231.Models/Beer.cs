using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KJWTMR_HTF_2022231.Models
{
    [Table("beers")]
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int Id { get; set; }
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Type Type { get; set; }
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

       


        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

       
    }
}
