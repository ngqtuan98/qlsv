namespace QLSV.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        public int Id { get; set; }

        public int id_SinhVien { get; set; }

        public int id_MonHoc { get; set; }

        public int id_DanhGia { get; set; }

        public double diemThi { get; set; }

        public virtual DanhGia DanhGia { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
