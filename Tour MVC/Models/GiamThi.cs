using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("GiamThi")]
    public partial class GiamThi
    {
        [Key]
        public int MaPhong { get; set; }
        [Key]
        public int MaGiaoVien { get; set; }
        public string NhiemVu { get; set; }

        [ForeignKey(nameof(MaGiaoVien))]
        [InverseProperty(nameof(GiaoVien.GiamThis))]
        public virtual GiaoVien MaGiaoVienNavigation { get; set; }
        [ForeignKey(nameof(MaPhong))]
        [InverseProperty(nameof(PhongThi.GiamThis))]
        public virtual PhongThi MaPhongNavigation { get; set; }
    }
}
