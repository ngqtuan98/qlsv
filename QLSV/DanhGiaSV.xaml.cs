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
    /// Interaction logic for DanhGiaSV.xaml
    /// </summary>
    public partial class DanhGiaSV : Window
    {
        public DanhGiaSV()
        {
            InitializeComponent();
        }

       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                    using (var db = new CSDLQlsv())//connect database
                    {
                        var dg = new DanhGia { DanhGia1 = tbDG.Text };
                        db.DanhGias.Add(dg);
                        db.SaveChanges();
                        Clear();
                        lsvDG.Items.Refresh();
                        lsvDG.ItemsSource = db.DanhGias.ToList();
                    }
                    displayLop();
               
               
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
                    int idDG = int.Parse(tbID.Text);
                    if (MessageBox.Show("Bạn thực sự muốn trường này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var remove = db.DanhGias.Find(idDG); //Tìm kiếm theo primary key
                        db.DanhGias.Remove(remove);
                        db.SaveChanges();
                        Clear();
                        lsvDG.Items.Refresh();
                        lsvDG.ItemsSource = db.DanhGias.ToList();
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
            int idDG = int.Parse(tbID.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var updateLop = db.DanhGias.Find(idDG);//Tìm kiếm theo primary key
                    updateLop.DanhGia1 = tbDG.Text;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvDG.ItemsSource = db.DanhGias.ToList();
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
                lsvDG.Items.Refresh();
                lsvDG.ItemsSource = db.DanhGias.ToList();
            }
        }
        public void Clear()
        {
            tbDG.Text = "";
            tbID.Text = "";
        }

        private void lsvLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            BaoCaoSV mwd = new BaoCaoSV();
            Close();
            mwd.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {
                lsvDG.Items.Refresh();
                lsvDG.ItemsSource = db.DanhGias.ToList();
            }
        }
    }
}
