using QLSV.Model;
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

namespace QLSV
{
    /// <summary>
    /// Interaction logic for Monhoc.xaml
    /// </summary>
    public partial class MonhocSV : Window
    {
        public MonhocSV()
        {
            InitializeComponent();
        }

        public bool KTM()
        {

            using (var db = new CSDLQlsv())//connect database
            {

                var dsgv = from ctgv in db.MonHocs
                           select ctgv.id_Nganh;
                if (dsgv.ToList().Count() > 3)
                {
                    return false;
                }
                else
                    return true;

            }


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            int idcbnganh = int.Parse(cbNganh.SelectedValue.ToString());


            try
            {
                if (KTM() == true)
                {
                    using (var db = new CSDLQlsv())//connect database
                    {
                        var dg = new MonHoc { tenMH = tbMH.Text, id_Nganh = idcbnganh };
                        db.MonHocs.Add(dg);
                        db.SaveChanges();
                        Clear();
                        lsvMH.Items.Refresh();
                        lsvMH.ItemsSource = db.MonHocs.ToList();
                    }
                    displayLop();
                }


                else
                {
                    MessageBox.Show("Mỗi ngành chỉ được 3 môn ", "Lỗi người dùng", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    int idMH = int.Parse(tbID.Text);
                    if (MessageBox.Show("Bạn thực sự muốn trường này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var remove = db.MonHocs.Find(idMH); //Tìm kiếm theo primary key
                        db.MonHocs.Remove(remove);
                        db.SaveChanges();
                        Clear();
                        lsvMH.Items.Refresh();
                        lsvMH.ItemsSource = db.MonHocs.ToList();
                    }
                }
                displayLop();
            }
            catch
            {
                MessageBox.Show("Id này đang được sử dụng ở nơi khác", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int idDG = int.Parse(tbID.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var updateLop = db.MonHocs.Find(idDG);//Tìm kiếm theo primary kdsdsdey
                    updateLop.tenMH = tbMH.Text;
                    updateLop.id_Nganh = int.Parse(cbNganh.SelectedValue.ToString());
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvMH.ItemsSource = db.MonHocs.ToList();
                }
                displayLop();
            }
            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void displayLop()
        {
            using (var db = new CSDLQlsv())//connect database
            {
                var dsn = from n in db.Nganhs
                          select n;
                cbNganh.ItemsSource = dsn.ToList();
                cbNganh.DisplayMemberPath = "tenNganh";
                cbNganh.SelectedValuePath = "Id";
                cbNganh.SelectedIndex = 0;
                lsvMH.ItemsSource = db.MonHocs.ToList();
            }
            lsvMH.Items.Refresh();
        }
        public void Clear()
        {
            tbMH.Text = "";
            tbID.Text = "";
        }


        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Phancong mwd = new Phancong();
            Close();
            mwd.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {
                var dsn = from n in db.Nganhs
                          select n;
                cbNganh.ItemsSource = dsn.ToList();
                cbNganh.DisplayMemberPath = "tenNganh";
                cbNganh.SelectedValuePath = "Id";
                cbNganh.SelectedIndex = 0;
                lsvMH.ItemsSource = db.MonHocs.ToList();
            }
            cbNganh.Items.Refresh();
        }

        

        private void btnAddGV_Click_1(object sender, RoutedEventArgs e)
        {
            NganhHoc nh = new NganhHoc();
            Close();
            nh.Show();
        }
    }
}
