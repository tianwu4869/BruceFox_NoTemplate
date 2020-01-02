using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BF.Entity
{
    [Table("Skins_List")]
    public class Skin
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column("Champion ID")]
        [ForeignKey("Champion")]
        public int Champion_ID { get; set; }
        public Champion Champion { get; set; }

        [Required]
        [Column("Skin Name")]
        public string Skin_Name { get; set; }
    }
}
