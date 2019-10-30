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
using System.Windows.Shapes;

namespace QLSV
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (CheckAcc() == true&&CheckPass()==true)
            {
                if (hasSpecialChar(tbAcc.Text) == false)
                {
                    if (tbAcc.Text == "Tuan123" && tbbPass.Text == "Tuan@123")
                    {
                        MainWindow mwd = new MainWindow();
                        Close();
                        mwd.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai Acc và pass", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Acc có ký tự đặc biệt", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Phải >= 6 và <= 15", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool CheckAcc()
        {
            var a = (tbAcc.Text).Length;
            if (a >= 6 && a <= 15)
                return true;
            else return false;

        }
        public bool CheckPass()
        {
            var a = (tbAcc.Text).Length;
            if (a >= 8 && a <= 20)
                return true;
            else return false;

        }
        public  bool hasSpecialChar( string input )
        {

            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_, ";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

    }
}
