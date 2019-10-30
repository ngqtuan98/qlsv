using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void lsvDSSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLop_Click(object sender, RoutedEventArgs e)
        {
            PhongHoc ph = new PhongHoc();
            Close();
            ph.Show();

        }

        private void btnNganh_Click(object sender, RoutedEventArgs e)
        {
            NganhHoc nh = new NganhHoc();
            Close();
            nh.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int stt;

            int idcbLop = int.Parse(cbLop.SelectedValue.ToString());
            int idcbNganh = int.Parse(cbNganh.SelectedValue.ToString());

            try
            {
                if (checkdiemthi() && checkdiemchuan() == true)
                {
                    using (var db = new CSDLQlsv())//connect database
                    {

                        try
                        {
                            var dssv = db.SinhViens.OrderByDescending(sv => sv.Id).ToList().FirstOrDefault();
                            stt = dssv.Id;

                        }
                        catch (Exception)
                        {
                            stt = 0;
                        }
                        var asv = new SinhVien
                        {

                            ten = tbTen.Text,
                            MSSV = "16" + cbNganh.Text + (string.Format("{0:000000}", stt)),
                            id_Lop = idcbLop,
                            id_Nganh = idcbNganh,
                            ngaySinh = DateTime.Parse(tbNgaySinh.Text),
                            gioiTinh = tbGioiTinh.Text,
                            truongTHPT = tbTHPT.Text,
                            diemThi = double.Parse(tbDT.Text),
                            diemChuan = double.Parse(tbDC.Text),
                        };
                        db.SinhViens.Add(asv);
                        db.SaveChanges();
                        Clear();
                        lsvDSSV.ItemsSource = db.SinhViens.ToList();
                        lsvDSSV.Items.Refresh();
                        MessageBox.Show("Dữ liệu đã dược cập nhật");
                    }

                    lsvDSSV.Items.Refresh();
                    Page_Loaded();
                }
                else
                {
                    MessageBox.Show("Điểm phải lớn hơn bằng 0 và nhỏ hơn 40", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            int idSV = int.Parse(tbId.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {

                    if (MessageBox.Show("Bạn thực sự muốn xoá Sinh Viên này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var rmsv = db.SinhViens.Find(idSV); //Tìm kiếm theo primary key
                        db.SinhViens.Remove(rmsv);
                        db.SaveChanges();
                        Clear();
                        lsvDSSV.Items.Refresh();
                        lsvDSSV.ItemsSource = db.SinhViens.ToList();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng liên hệ với bộ phận kỹ thuật", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            int idSV = int.Parse(tbId.Text);
            int idcbLop = int.Parse(cbLop.SelectedValue.ToString());
            int idcbNganh = int.Parse(cbNganh.SelectedValue.ToString());

            try
            {
                if (checkdiemthi() && checkdiemchuan() == true)
                {
                    using (var db = new CSDLQlsv())//connect database
                    {


                        var updateSV = db.SinhViens.Find(idSV);//Tìm kiếm theo primary key
                        updateSV.ten = tbTen.Text;
                        updateSV.MSSV = tbMSSV.Text;
                        updateSV.id_Lop = idcbLop;
                        updateSV.id_Nganh = idcbNganh;
                        updateSV.ngaySinh = DateTime.Parse(tbNgaySinh.Text);
                        updateSV.gioiTinh = tbGioiTinh.Text;
                        updateSV.truongTHPT = tbTHPT.Text;
                        updateSV.diemThi = double.Parse(tbDT.Text);
                        updateSV.diemChuan = double.Parse(tbDC.Text);
                        db.SaveChanges();
                        Clear();
                        MessageBox.Show("Dữ liệu đã dược cập nhật");
                        lsvDSSV.ItemsSource = db.SinhViens.ToList();
                    }

                    Page_Loaded();
                }

                else
                {
                    MessageBox.Show("Điểm phải lớn hơn bằng 0 và nhỏ hơn 40", "Some title", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void Page_Loaded()
        {
            try
            {
                int stt;
                using (var db = new CSDLQlsv())//connect database
                {

                    var dssv = db.SinhViens.OrderByDescending(sv => sv.Id).ToList().FirstOrDefault();
                    stt = dssv.Id;

                    lsvDSSV.ItemsSource = db.SinhViens.ToList();
                    lsvDSSV.Items.Refresh();
                    var dslop = from lop in db.Lops
                                select lop;
                    cbLop.ItemsSource = dslop.ToList();
                    cbLop.DisplayMemberPath = "tenLop";
                    cbLop.SelectedValuePath = "Id";
                    cbLop.SelectedIndex = 0;

                    var dsnganh = from nganh in db.Nganhs
                                  select nganh;
                    cbNganh.ItemsSource = dsnganh.ToList();
                    cbNganh.DisplayMemberPath = "tenNganh";
                    cbNganh.SelectedValuePath = "Id";
                    cbNganh.SelectedIndex = 0;
                }
                tbId.Text = stt.ToString();
                cbLop.Items.Refresh();
                cbNganh.Items.Refresh();
                lsvDSSV.Items.Refresh();
            }
            catch (Exception)
            { }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded();
        }

        private void cbLop_Loaded(object sender, RoutedEventArgs e)
        {
            Page_Loaded();
        }

        public void Clear()
        {
            tbTen.Text = "";
            tbMSSV.Text = "";
            cbLop.Text = "";
            cbNganh.Text = "";
            tbNgaySinh.Text = "";
            tbGioiTinh.Text = "";
            tbTHPT.Text = "";
            tbDT.Text = "";
            tbDC.Text = "";
        }

        private void btnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            BaoCaoSV btnBao = new BaoCaoSV();

            btnBao.Show();
        }

        private void btnDG_Click(object sender, RoutedEventArgs e)
        {
            DanhGiaSV btnDanhgia = new DanhGiaSV();
            btnDanhgia.Show();
        }

       
        private void btnMH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGV_Click(object sender, RoutedEventArgs e)
        {
            GiangVienDay gv = new GiangVienDay();
            Close();
            gv.Show();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int stt;
            using (var db = new CSDLQlsv())//connect database
            {

                var dssv = db.SinhViens.OrderByDescending(sv => sv.Id).ToList().FirstOrDefault();
                stt = dssv.Id;

                lsvDSSV.ItemsSource = db.SinhViens.ToList();
                lsvDSSV.Items.Refresh();
                var dslop = from lop in db.Lops
                            select lop;
                cbLop.ItemsSource = dslop.ToList();
                cbLop.DisplayMemberPath = "tenLop";
                cbLop.SelectedValuePath = "Id";
                cbLop.SelectedIndex = 0;

                var dsnganh = from nganh in db.Nganhs
                              select nganh;
                cbNganh.ItemsSource = dsnganh.ToList();
                cbNganh.DisplayMemberPath = "tenNganh";
                cbNganh.SelectedValuePath = "Id";
                cbNganh.SelectedIndex = 0;
            }

            tbId.Text = stt.ToString();
            cbLop.Items.Refresh();
            cbNganh.Items.Refresh();
            lsvDSSV.Items.Refresh();
        }

        public bool checkdiemthi()
        {

            int diemthi = int.Parse(tbDT.Text);
            if (diemthi >= 0 && diemthi < 40)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public bool checkdiemchuan()
        {

            int diemthi = int.Parse(tbDT.Text);
            if (diemthi >= 0 && diemthi < 40)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnTK_Click(object sender, RoutedEventArgs e)
        {
            TiemKiem tk = new TiemKiem();
            tk.Show();
        }

        private void BtnPL_Click(object sender, RoutedEventArgs e)
        {
            Phancong pc = new Phancong();
            Close();
            pc.Show();
        }

        private void Tbtk_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {
                var query = (from c in db.SinhViens
                            where c.ten.StartsWith(tbtk.Text)
                            select c).ToList();

                lsvDSSV.ItemsSource = query;
               
            }

            lsvDSSV.Items.Refresh();
        }

       
    }
}
          
          
          