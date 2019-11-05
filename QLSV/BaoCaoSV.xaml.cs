using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using QLSV.Model;

namespace QLSV
{
    /// <summary>
    /// Interaction logic for BaoCaoSV.xaml
    /// </summary>
    public partial class BaoCaoSV : Window
    {
        public BaoCaoSV()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int idcbsv = int.Parse(cbSV.SelectedValue.ToString());
                int idcbdg = int.Parse(cbDG.SelectedValue.ToString());
                int idcbmh = int.Parse(cbMH.SelectedValue.ToString());
                int diem = int.Parse(tbDT.Text.ToString());

                    using (var db = new CSDLQlsv())//connect database
                    {
                        var pc = new BaoCao { id_SinhVien = idcbsv, id_DanhGia = idcbdg, id_MonHoc = idcbmh, diemThi = diem };
                        db.BaoCaos.Add(pc);
                        db.SaveChanges();
                        Clear();
                        lsvBC.Items.Refresh();
                        lsvBC.ItemsSource = db.BaoCaos.ToList();
                    }

                    displayLop();

            }
            catch (Exception)
            {
                MessageBox.Show("Không được trống", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    int method = int.Parse(tbID.Text);
                    if (MessageBox.Show("Bạn thực sự muốn xoá  này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var remove = db.BaoCaos.Find(method); //Tìm kiếm theo primary key
                        db.BaoCaos.Remove(remove);
                        db.SaveChanges();
                        Clear();
                        lsvBC.Items.Refresh();
                        lsvBC.ItemsSource = db.BaoCaos.ToList();
                    }
                }
                displayLop();
            }
            catch
            {
                MessageBox.Show("Vui lòng liên hệ với bộ phận kỹ thuật", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idcbsv = int.Parse(cbSV.SelectedValue.ToString());
                int idcbdg = int.Parse(cbDG.SelectedValue.ToString());
                int idcbmh = int.Parse(cbMH.SelectedValue.ToString());
                int diem = int.Parse(tbDT.Text.ToString());
                int method = int.Parse(tbID.Text);
                using (var db = new CSDLQlsv())//connect database
                {
                    var updatepc = db.BaoCaos.Find(method);//Tìm kiếm theo primary key

                    updatepc.id_SinhVien = idcbsv;
                    updatepc.id_DanhGia = idcbdg;
                    updatepc.id_MonHoc = idcbmh;
                    updatepc.diemThi = diem;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvBC.ItemsSource = db.Lops.ToList();
                }
                displayLop();
            }
            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void displayLop()
        {
            using (var db = new CSDLQlsv())//connect database
            {
                lsvBC.Items.Refresh();
                lsvBC.ItemsSource = db.BaoCaos.ToList();
                var dsdg = from dg in db.DanhGias
                           select dg;
                cbDG.ItemsSource = dsdg.ToList();
                cbDG.DisplayMemberPath = "DanhGia1";
                cbDG.SelectedValuePath = "Id";
                cbDG.SelectedIndex = 0;

                var dsmon = from mh in db.MonHocs
                            select mh;
                cbMH.ItemsSource = dsmon.ToList();
                cbMH.DisplayMemberPath = "tenMH";
                cbMH.SelectedValuePath = "Id";
                cbMH.SelectedIndex = 0;

                var dssv = from sv in db.SinhViens
                            select sv;
                cbSV.ItemsSource = dssv.ToList();
                cbSV.DisplayMemberPath = "ten";
                cbSV.SelectedValuePath = "Id";
                cbSV.SelectedIndex = 0;
            }
            cbSV.Items.Refresh();
            cbMH.Items.Refresh();
            cbDG.Items.Refresh();
            lsvBC.Items.Refresh();
        }
        public void Clear()
        {
            cbSV.Text = "";
            tbID.Text = "";
            cbDG.Text = "";
            cbMH.Text = "";
            tbDT.Text = "";
           
        }


        private void btnLOPADD_Click(object sender, RoutedEventArgs e)
        {
            PhongHoc ph = new PhongHoc();
            Close();
            ph.Show();
        }

        private void btnGVADD_Click(object sender, RoutedEventArgs e)
        {
            DanhGiaSV dg = new DanhGiaSV();
            Close();
            dg.Show();
        }

        private void btnMHADD_Click(object sender, RoutedEventArgs e)
        {
            MonhocSV mh = new MonhocSV();
            Close();
            mh.Show();
        }

        private void txtsiso_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {
                lsvBC.Items.Refresh();
                lsvBC.ItemsSource = db.BaoCaos.ToList();
                var dsdg = from dg in db.DanhGias
                           select dg;
                cbDG.ItemsSource = dsdg.ToList();
                cbDG.DisplayMemberPath = "DanhGia1";
                cbDG.SelectedValuePath = "Id";
                cbDG.SelectedIndex = 0;

                var dsmon = from mh in db.MonHocs
                            select mh;
                cbMH.ItemsSource = dsmon.ToList();
                cbMH.DisplayMemberPath = "tenMH";
                cbMH.SelectedValuePath = "Id";
                cbMH.SelectedIndex = 0;

                var dssv = from sv in db.SinhViens
                           select sv;
                cbSV.ItemsSource = dssv.ToList();
                cbSV.DisplayMemberPath = "ten";
                cbSV.SelectedValuePath = "Id";
                cbSV.SelectedIndex = 0;
            }
            cbSV.Items.Refresh();
            cbMH.Items.Refresh();
            cbDG.Items.Refresh();
            lsvBC.Items.Refresh();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwd = new MainWindow();
            Close();
            mwd.Show();
        }
    }
}
