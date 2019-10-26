namespace QLSV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonHoc")]
    public partial class MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonHoc()
        {
            BaoCaos = new HashSet<BaoCao>();
            ChiTietGiangViens = new HashSet<ChiTietGiangVien>();
        }

        public int Id { get; set; }

        public string tenMH { get; set; }

        public double? diemMon { get; set; }

        public int id_Nganh { get; set; }

        public int id_GiangVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCao> BaoCaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGiangVien> ChiTietGiangViens { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual Nganh Nganh { get; set; }
    }
}
