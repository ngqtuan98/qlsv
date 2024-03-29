﻿using System;
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
    /// Interaction logic for Phancong.xaml
    /// </summary>
    public partial class Phancong : Window
    {
        public Phancong()
        {
            InitializeComponent();
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            try 
            {
                int idcblop = int.Parse(cbLop.SelectedValue.ToString());
                int idcbgv = int.Parse(cbGV.SelectedValue.ToString());
                int idcbmh = int.Parse(cbMH.SelectedValue.ToString());
                int siso = int.Parse(txtsiso.Text.ToString());

                if (siso <= 40)
                {
                    using (var db = new CSDLQlsv())//connect database
                    {
                        var pc = new ChiTietGiangVien { Id_Lop = idcblop, id_GiangVien = idcbgv, id_MonHoc = idcbmh, SiSo = siso };
                        db.ChiTietGiangViens.Add(pc);
                        db.SaveChanges();
                        Clear();
                        lsvPC.Items.Refresh();
                        lsvPC.ItemsSource = db.ChiTietGiangViens.ToList();
                    }

                    displayLop();

                }
                else
                    tbTB.Text = "Sĩ số phải bé hơn hoặc bằng";
            }
            catch (Exception)
            {
                tbTB.Text = "KHÔNG ĐƯỢC TRỐNG";
            }
               
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CSDLQlsv())//connect database
                {
                    int idgv = int.Parse(txtIDpc.Text);
                    if (MessageBox.Show("Bạn thực sự muốn xoá nhân viên này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var rmpc = db.ChiTietGiangViens.Find(idgv); //Tìm kiếm theo primary key
                        db.ChiTietGiangViens.Remove(rmpc);
                        db.SaveChanges();
                        Clear();
                        lsvPC.Items.Refresh();
                        lsvPC.ItemsSource = db.ChiTietGiangViens.ToList();
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
                int idcblop = int.Parse(cbLop.SelectedValue.ToString());
                int idcbgv = int.Parse(cbGV.SelectedValue.ToString());
                int idcbmh = int.Parse(cbMH.SelectedValue.ToString());
                int siso = int.Parse(txtsiso.Text.ToString());
                int idgv = int.Parse(txtIDpc.Text);
                using (var db = new CSDLQlsv())//connect database
                {
                    var updatepc = db.ChiTietGiangViens.Find(idgv);//Tìm kiếm theo primary key

                    updatepc.Id_Lop = idcblop;
                    updatepc.id_GiangVien = idcbgv;
                    updatepc.id_MonHoc = idcbmh;
                    updatepc.SiSo = siso;
                    db.SaveChanges();
                    Clear();
                    MessageBox.Show("Dữ liệu đã dược cập nhật");
                    lsvPC.ItemsSource = db.Lops.ToList();
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
                lsvPC.Items.Refresh();
                lsvPC.ItemsSource = db.ChiTietGiangViens.ToList();
                var dsgv = from gv in db.GiangViens
                           select gv;
                cbGV.ItemsSource = dsgv.ToList();
                cbGV.DisplayMemberPath = "tenGV";
                cbGV.SelectedValuePath = "Id";
                cbGV.SelectedIndex = 0;

                var dsmon = from mh in db.MonHocs
                            select mh;
                cbMH.ItemsSource = dsmon.ToList();
                cbMH.DisplayMemberPath = "tenMH";
                cbMH.SelectedValuePath = "Id";
                cbMH.SelectedIndex = 0;

                var dslop = from lop in db.Lops
                            select lop;
                cbLop.ItemsSource = dslop.ToList();
                cbLop.DisplayMemberPath = "tenLop";
                cbLop.SelectedValuePath = "Id";
                cbLop.SelectedIndex = 0;
            }
            cbLop.Items.Refresh();
            cbMH.Items.Refresh();
            cbGV.Items.Refresh();
            lsvPC.Items.Refresh();
        }
        public void Clear()
        {
            cbLop.Text = "";
            txtIDpc.Text = "";
            cbGV.Text = "";
            cbMH.Text = "";
            txtsiso.Text = "";
            tbTB.Text = "";
        }


        private void btnLOPADD_Click(object sender, RoutedEventArgs e)
        {
            PhongHoc ph = new PhongHoc();
            Close();
            ph.Show();
        }

        private void btnGVADD_Click(object sender, RoutedEventArgs e)
        {
            GiangVienDay gv = new GiangVienDay();
            Close();
            gv.Show();
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
                lsvPC.ItemsSource = db.ChiTietGiangViens.ToList();
                
                
                var dsgv = from gv in db.GiangViens
                           select gv;
                cbGV.ItemsSource = dsgv.ToList();
                cbGV.DisplayMemberPath = "tenGV";
                cbGV.SelectedValuePath = "Id";
                cbGV.SelectedIndex = 0;

                var dsmon = from mh in db.MonHocs
                            select mh;
                cbMH.ItemsSource = dsmon.ToList();
                cbMH.DisplayMemberPath = "tenMH";
                cbMH.SelectedValuePath = "Id";
                cbMH.SelectedIndex = 0;

                var dslop = from lop in db.Lops
                            select lop;
                cbLop.ItemsSource = dslop.ToList();
                cbLop.DisplayMemberPath = "tenLop";
                cbLop.SelectedValuePath = "Id";
                cbLop.SelectedIndex = 0;
            }
            cbLop.Items.Refresh();
            cbMH.Items.Refresh();
            cbGV.Items.Refresh();
            lsvPC.Items.Refresh();
        }
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwd = new MainWindow();
            Close();
            mwd.Show();
        }
        public bool Checksiso(int siso)

        {
            if (siso <= 40)
            {
                return true;
            }
            return false;
        }
    }
}

