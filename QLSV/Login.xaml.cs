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
            tbAcc.Text = "test@123456";
            tbbPass.Text = "Test@123";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FLogin(tbAcc.Text, tbbPass.Text);

        }

        public void FLogin(string acc, string pass)
        {
            if (CheckAcc(acc) == true && CheckPassLength(pass) == true)
            {
                if (CheckStartWithSpecial(acc) == true && CheckStartWithNumber(acc) == true)
                {
                    if (CheckPassNumber_Special_Upper(pass) == true)
                    {
                        if (KhoangTrang(tbAcc.Text) == false)
                        {
                            if (acc == "test@123456" && pass == "Test@123")
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
                            MessageBox.Show("Không khoảng trắng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password phải có ít nhất 1 số, 1 chữ hoa và 1 ký tự", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("không bắt đầu bằng ký tự hoặc số", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Phải >= 6 và <= 15", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CheckStartWithSpecial(string Acc)
        {
            var specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
           
            foreach (var item in specialChar)
            {
                if (Acc.StartsWith(item.ToString())) return false;
            }
            return true;

        }
        public bool CheckStartWithNumber(string Acc)
        {


            for (int i = 0; i <= 9; i++)
            {
                if (Acc.StartsWith(i.ToString())) return false;
            }
            return true;

        }
        public bool CheckAcc(string Acc)
        {
            var a = Acc.Length;
            if (a >= 6 && a <= 15)
            {
                return true;
            }
            else return false;

        }
        public bool CheckPassLength(string Pass)
        {
            var a = (Pass).Length;
            if (a >= 8 && a <= 20)
                return true;
            else return false;

        }
        public bool KhoangTrang(string input)
        {

            if (input.IndexOf(" ") != -1)
                return true;
            else return false;
        }

        public bool HasSpecialChar(string input)
        {

            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;

        }

        


        public bool CheckPassNumber_Special_Upper(string input)
        {
            int i = 0; int chu_so = 0; int ky_tu_dac_biet = 0;
            int l = input.Length;
            int inHoa = 0;
            while (i < l)
            {
                if ((input[i] >= 'A' && input[i] <= 'Z'))
                {
                    inHoa++;
                }
                else if (input[i] >= '0' && input[i] <= '9')
                {
                    chu_so++;
                }

                i++;
            }
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                    ky_tu_dac_biet++;
            }


            if (inHoa > 0 && chu_so > 0 && ky_tu_dac_biet > 0)
            {
                return true;
            }
            return false;
        }       

    }
}
