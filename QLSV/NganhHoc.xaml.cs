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
    /// Interaction logic for Nganh.xaml
    /// </summary>
    public partial class NganhHoc : Window
    {
        public NganhHoc()
        {
            InitializeComponent();
            displayNganh();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var nganh = new Nganh { tenNganh = tbNganh.Text };
                    db.Nganhs.Add(nganh);
                    db.SaveChanges();
                    Clear();
                    lsvNganh.Items.Refresh();
                    lsvNganh.ItemsSource = db.Nganhs.ToList();
                }
                displayNganh();
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
                int idNganh = int.Parse(tbIDNganh.Text);
                using (var db = new CSDLQlsv())//connect database
                {
                    
                    if (MessageBox.Show("Bạn thực sự muốn xoá ngành này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var rmnganh = db.Nganhs.Find(idNganh); //Tìm kiếm theo primary key
                        db.Nganhs.Remove(rmnganh);
                        db.SaveChanges();
                        Clear();
                        lsvNganh.Items.Refresh();
                        lsvNganh.ItemsSource = db.Lops.ToList();
                    }
                }
                displayNganh();
            }
            catch
            {
                MessageBox.Show("Vui lòng liên hệ với bộ phận kỹ thuật", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            int idNganh = int.Parse(tbIDNganh.Text);
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    var updateNganh = db.Nganhs.Find(idNganh);//Tìm kiếm theo primary key
                    updateNganh.tenNganh = tbNganh.Text;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvNganh.ItemsSource = db.Nganhs.ToList();
                }
                displayNganh();
            }

            catch
            {
                MessageBox.Show("Không nhập đúng theo yêu cầu", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void displayNganh()
        {
            using (var db = new CSDLQlsv())//connect database
            {
                lsvNganh.Items.Refresh();
                lsvNganh.ItemsSource = db.Nganhs.ToList();
            }
        }
        public void Clear()
        {
            tbNganh.Text = "";
            tbIDNganh.Text = "";
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwd = new MainWindow();
            Close();
            mwd.Show();
        }
    }
}
