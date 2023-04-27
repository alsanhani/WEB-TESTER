using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Models
{
    [Table("Accountant_low")]
    public partial class AccountantLow
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }
        [Column("ID_l")]
        public int? IdL { get; set; }
        [Column("TYPE")]
        public int? Type { get; set; }

        [ForeignKey("IdL")]
        [InverseProperty("AccountantLows")]
        public virtual AccountantInfo? IdLNavigation { get; set; }
    }
}
