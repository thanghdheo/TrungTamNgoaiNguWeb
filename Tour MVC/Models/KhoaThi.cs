using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("KhoaThi")]
    public partial class KhoaThi
    {
        public KhoaThi()
        {
            DuThis = new HashSet<DuThi>();
            PhongThis = new HashSet<PhongThi>();
        }

        [Key]
        public int MaKhoaThi { get; set; }
        [Required]
        public string TenKhoa { get; set; }
        [Column(TypeName = "date")]
        public DateTime NgayThi { get; set; }
        public bool ChotSo { get; set; }

        [InverseProperty(nameof(DuThi.MaKhoaThiNavigation))]
        public virtual ICollection<DuThi> DuThis { get; set; }
        [InverseProperty(nameof(PhongThi.MaKhoaThiNavigation))]
        public virtual ICollection<PhongThi> PhongThis { get; set; }
    }
}
