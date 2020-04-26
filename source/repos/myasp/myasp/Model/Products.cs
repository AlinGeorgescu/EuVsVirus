using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myasp.Model
{
    [Table("products$")]
    public partial class Products
    {
        [StringLength(255)]
        public string Name { get; set; }
        [Column(" Price")]
        [StringLength(255)]
        public string Price { get; set; }
        [Column(" Location")]
        [StringLength(255)]
        public string Location { get; set; }
        [Column(" Image")]
        [StringLength(255)]
        public string Image { get; set; }
        [Column(" Link")]
        [StringLength(255)]
        public string Link { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}
