using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BF.Entity
{
    [Table("Champions_List")]
    public class Champion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name can only contain alphabet.")]
        public string Name { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Please enter valid difficulty.")]
        public int Difficulty { get; set; }

        [Required]
        [RegularExpression("(Controller|Fighter|Mage|Marksman|Slayer|Tank)", ErrorMessage = "Please enter valid champion class.")]
        public string Class { get; set; }
    }
}
