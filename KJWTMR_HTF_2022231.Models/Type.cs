using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KJWTMR_HTF_2022231.Models
{
    [Table("types")]
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeName { get; set; }


        [NotMapped]
        public virtual ICollection<Beer> Beers { get; set; }

        public Type()
        {
            this.Beers = new HashSet<Beer>();
        }
    }
}
