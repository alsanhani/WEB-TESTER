using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Models
{
    [Table("Accountant_info")]
    public partial class AccountantInfo
    {
        public AccountantInfo()
        {
            AccountantLows = new HashSet<AccountantLow>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("issue_place")]
        [StringLength(100)]
        public string? IssuePlace { get; set; }
        [Column("name")]
        [StringLength(100)]
        [Display(Name = "اسم الطالب")]
        [Required(ErrorMessage = "يجب ادخال اسم الطالب")]
        [MinLength(3, ErrorMessage = "يجب ان يكون اكثر من 3 احرف")]
        public string? Name { get; set; }

        [InverseProperty("IdLNavigation")]
        public virtual ICollection<AccountantLow> AccountantLows { get; set; }
    }
}
