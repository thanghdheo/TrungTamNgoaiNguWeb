using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        public TrinhDo()
        {
            DuThis = new HashSet<DuThi>();
            PhongThis = new HashSet<PhongThi>();
        }

        [Key]
        public int MaTrinhDo { get; set; }
        [Required]
        [StringLength(2)]
        public string TenTrinhDo { get; set; }

        [InverseProperty(nameof(DuThi.MaTrinhDoNavigation))]
        public virtual ICollection<DuThi> DuThis { get; set; }
        [InverseProperty(nameof(PhongThi.MaTrinhDoNavigation))]
        public virtual ICollection<PhongThi> PhongThis { get; set; }
    }
}
