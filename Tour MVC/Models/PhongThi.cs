using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("PhongThi")]
    public partial class PhongThi
    {
        public PhongThi()
        {
            GiamThis = new HashSet<GiamThi>();
            ThiSinhs = new HashSet<ThiSinh>();
        }

        [Key]
        public int MaPhong { get; set; }
        [Required]
        public string TenPhong { get; set; }
        public int MaKhoaThi { get; set; }
        public int MaTrinhDo { get; set; }
        public bool ChotSo { get; set; }

        [ForeignKey(nameof(MaKhoaThi))]
        [InverseProperty(nameof(KhoaThi.PhongThis))]
        public virtual KhoaThi MaKhoaThiNavigation { get; set; }
        [ForeignKey(nameof(MaTrinhDo))]
        [InverseProperty(nameof(TrinhDo.PhongThis))]
        public virtual TrinhDo MaTrinhDoNavigation { get; set; }
        [InverseProperty(nameof(GiamThi.MaPhongNavigation))]
        public virtual ICollection<GiamThi> GiamThis { get; set; }
        [InverseProperty(nameof(ThiSinh.MaPhongNavigation))]
        public virtual ICollection<ThiSinh> ThiSinhs { get; set; }
    }
}
