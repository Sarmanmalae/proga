using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "C")
                textlabel.Text = "";
            else if (str == "⌫" && textlabel.Text.Length>0)
            {
                int start = 0;
                int length = textlabel.Text.Length - 1;
                string h = textlabel.Text.Substring(start, length);
                textlabel.Text = h;
            }
            else if (str == "⌫" && textlabel.Text.Length == 0)
            {
                textlabel.Text = "";
            }
            else if (str == "=")
            {
                string answer = new DataTable().Compute(textlabel.Text, null).ToString();
                textlabel.Text = answer;
            }
            else if (!((str == "+" || str == "/" || str == "*" || str == "-") && (textlabel.Text.Length==0 || textlabel.Text.EndsWith("+") || textlabel.Text.EndsWith("/") || textlabel.Text.EndsWith("*") || textlabel.Text.EndsWith("-"))))
                if (textlabel.Text.Length < 15)
                    textlabel.Text += str;
        }

    }
}
