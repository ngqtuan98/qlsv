namespace QLSV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGiangVien")]
    public partial class ChiTietGiangVien
    {
        public int id { get; set; }

        public int Id_Lop { get; set; }

        public int id_GiangVien { get; set; }

        public int id_MonHoc { get; set; }

        public int? SiSo { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
