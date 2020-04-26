using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myasp.Model
{
    [Table("products (1)")]
    public partial class Products1
    {
        [StringLength(50)]
        public string Name { get; set; }
        [Column(" Price")]
        [StringLength(50)]
        public string Price { get; set; }
        [Column(" Location")]
        [StringLength(50)]
        public string Location { get; set; }
        [Column(" Image")]
        [StringLength(50)]
        public string Image { get; set; }
        [Column(" Link")]
        [StringLength(50)]
        public string Link { get; set; }
    }
}
