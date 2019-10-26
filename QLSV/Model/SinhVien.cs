namespace QLSV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            BaoCaos = new HashSet<BaoCao>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [StringLength(10)]
        public string gioiTinh { get; set; }

        [StringLength(100)]
        public string truongTHPT { get; set; }

        public double? diemThi { get; set; }

        public double? diemChuan { get; set; }

        [StringLength(50)]
        public string MSSV { get; set; }

        public int id_Nganh { get; set; }

        public int id_Lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCao> BaoCaos { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual Nganh Nganh { get; set; }
    }
}
