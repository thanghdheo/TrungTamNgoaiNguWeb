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
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Căn cước công dân có 12 ký tự")]
        [Range(0, long.MaxValue, ErrorMessage = "Chứng minh không hợp lệ")]
        [Required]
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
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại có 10 ký tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public string SoDienThoai { get; set; }
        [Required]
        public string Email { get; set; }

        [InverseProperty(nameof(DuThi.CccdNavigation))]
        public virtual ICollection<DuThi> DuThis { get; set; }
        [InverseProperty(nameof(ThiSinh.CccdNavigation))]
        public virtual ICollection<ThiSinh> ThiSinhs { get; set; }
    }
}
