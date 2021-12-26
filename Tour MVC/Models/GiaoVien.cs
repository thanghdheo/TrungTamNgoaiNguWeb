using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        public GiaoVien()
        {
            GiamThis = new HashSet<GiamThi>();
        }

        [Key]
        public int MaGiaoVien { get; set; }
        [Required]
        public string HoGiaoVien { get; set; }
        [Required]
        public string TenGiaoVien { get; set; }

        [InverseProperty(nameof(GiamThi.MaGiaoVienNavigation))]
        public virtual ICollection<GiamThi> GiamThis { get; set; }
    }
}
