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
    /// Interaction logic for GiangVien.xaml
    /// </summary>
    public partial class GiangVienDay : Window
    {
        public GiangVienDay()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var gv = new GiangVien { tenGV = tbGV.Text };
                    db.GiangViens.Add(gv);
                    db.SaveChanges();
                    Clear();
                    lsvGV.Items.Refresh();
                    lsvGV.ItemsSource = db.GiangViens.ToList();
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
                    int idGV = int.Parse(tbID.Text);
                    if (MessageBox.Show("Bạn thực sự muốn trường này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var remove = db.GiangViens.Find(idGV); //Tìm kiếm theo primary key
                        db.GiangViens.Remove(remove);
                        db.SaveChanges();
                        Clear();
                        lsvGV.Items.Refresh();
                        lsvGV.ItemsSource = db.GiangViens.ToList();
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
            int idGV = int.Parse(tbID.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var updateLop = db.GiangViens.Find(idGV);//Tìm kiếm theo primary key
                    updateLop.tenGV = tbGV.Text;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvGV.ItemsSource = db.GiangViens.ToList();
                }
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
                lsvGV.Items.Refresh();
                lsvGV.ItemsSource = db.GiangViens.ToList();
            }
        }
        public void Clear()
        {
            tbGV.Text = "";
            tbID.Text = "";
        }

        private void lsvLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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


                lsvGV.ItemsSource = db.GiangViens.ToList();

            }
            lsvGV.Items.Refresh();
        }
    }
}
