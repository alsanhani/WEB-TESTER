using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Models
{
    [Keyless]
    [Table("MARKS2")]
    public partial class Marks2
    {
        public int? M1 { get; set; }
        public int? M2 { get; set; }
        public int? M3 { get; set; }
        public int? M4 { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        [Column("TYPE")]
        [StringLength(10)]
        public string? Type { get; set; }

        [ForeignKey("Id")]
        public virtual AccountantInfo? IdNavigation { get; set; }
    }
}
