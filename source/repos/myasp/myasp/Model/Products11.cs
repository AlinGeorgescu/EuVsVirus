using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myasp.Model
{
    [Table("'products (1)$'")]
    public partial class Products11
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
    }
}
