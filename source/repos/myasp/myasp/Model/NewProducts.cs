using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myasp.Model
{
    [Table("newProducts")]
    public partial class NewProducts
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [Required]
        [StringLength(100)]
        public string Image { get; set; }
        [Required]
        [StringLength(150)]
        public string Link { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}
