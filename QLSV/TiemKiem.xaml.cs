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
    /// Interaction logic for TiemKiem.xaml
    /// </summary>
    public partial class TiemKiem : Window
    {
        public TiemKiem()
        {
            InitializeComponent();
        }

    private void CbSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {
                var query = db.BaoCaos.Where(sv => sv.id_SinhVien == (int)cbSV.SelectedValue);
                lsvTK.ItemsSource = db.BaoCaos.ToList();
            }
            lsvTK.Items.Refresh();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new CSDLQlsv())//connect database
            {  

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

            
        }
    }
}
