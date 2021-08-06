using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Val_Bogus
{
    [Table("tbl_animals")]
    public class Animal
    {
        [Key]
        public int Id { get; protected set; }
        [Required]
        [StringLength(50)]
        public string Kind { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    
    }
}
