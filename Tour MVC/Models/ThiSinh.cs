using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tour_MVC.Models
{
    [Table("ThiSinh")]
    public partial class ThiSinh
    {
        [Key]
        public int MaPhong { get; set; }
        [Key]
        [Column("CCCD")]
        [StringLength(12)]
        public string Cccd { get; set; }
        [Required]
        [Column("SBD")]
        [StringLength(5)]
        public string Sbd { get; set; }
        public int? DiemNghe { get; set; }
        public int? DiemDoc { get; set; }
        public int? DiemNoi { get; set; }
        public int? DiemViet { get; set; }

        [ForeignKey(nameof(Cccd))]
        [InverseProperty(nameof(NguoiDung.ThiSinhs))]
        public virtual NguoiDung CccdNavigation { get; set; }
        [ForeignKey(nameof(MaPhong))]
        [InverseProperty(nameof(PhongThi.ThiSinhs))]
        public virtual PhongThi MaPhongNavigation { get; set; }
    }
}
