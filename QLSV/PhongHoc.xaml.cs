﻿using QLSV.Model;
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
    /// Interaction logic for Lop.xaml
    /// </summary>
    public partial class PhongHoc : Window
    {

        public PhongHoc()
        {
            InitializeComponent();
            displayLop();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var lop = new Lop { tenLop = tbLop.Text };
                    db.Lops.Add(lop);
                    db.SaveChanges();
                    Clear();
                    lsvLop.Items.Refresh();
                    lsvLop.ItemsSource = db.Lops.ToList();
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
                    int idLop = int.Parse(txtIDLop.Text);
                    if (MessageBox.Show("Bạn thực sự muốn trường này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var rmlop = db.Lops.Find(idLop); //Tìm kiếm theo primary key
                        db.Lops.Remove(rmlop);
                        db.SaveChanges();
                        Clear();
                        lsvLop.Items.Refresh();
                        lsvLop.ItemsSource = db.Lops.ToList();
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
            int idLop = int.Parse(txtIDLop.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var updateLop = db.Lops.Find(idLop);//Tìm kiếm theo primary key
                    updateLop.tenLop = tbLop.Text;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvLop.ItemsSource = db.Lops.ToList();
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
                lsvLop.Items.Refresh();
                lsvLop.ItemsSource = db.Lops.ToList();
            }
        }
        public void Clear()
        {
            tbLop.Text = "";
            txtIDLop.Text = "";
        }

        private void lsvLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwd = new MainWindow();
            Close();
            mwd.Show();
        }
    }
}
