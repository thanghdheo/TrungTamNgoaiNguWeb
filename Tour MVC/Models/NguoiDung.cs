using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            DuThis = new HashSet<DuThi>();
            ThiSinhs = new HashSet<ThiSinh>();
        }

        [Key]
        [Column("CCCD")]
        [StringLength(12)]
        public string Cccd { get; set; }
        [Required]
        public string HoNguoiDung { get; set; }
        [Required]
        public string TenNguoiDung { get; set; }
        public bool GioiTinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string NoiSinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayCap { get; set; }
        [Required]
        public string NoiCap { get; set; }
        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }
        [Required]
        public string Email { get; set; }

        [InverseProperty(nameof(DuThi.CccdNavigation))]
        public virtual ICollection<DuThi> DuThis { get; set; }
        [InverseProperty(nameof(ThiSinh.CccdNavigation))]
        public virtual ICollection<ThiSinh> ThiSinhs { get; set; }
    }
}
