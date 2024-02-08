using System.Collections.ObjectModel;
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

namespace ex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> math;
        public MainWindow()
        {
            InitializeComponent();

            math = new ObservableCollection<string> {};
            mathList.ItemsSource = math;

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button && ((Button)el).Name != "button1" && ((Button)el).Name != "button2")
                {
                    ((Button)el).Click += Button_Click;
                }
            }


        }

        List<string> history = new List<string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;


            if (str == "C")
            {
                textlabel.Text = "";
                textlabel.Text = "";
            }

            else if (str == "⌫" && textlabel.Text.Length > 0)
            {
                int start = 0;
                int length = textlabel.Text.Length - 1;
                string h = textlabel.Text.Substring(start, length);
                textlabel.Text = h;

                int start2 = 0;
                int length2 = textlabel2.Text.Length - 1;
                string h2 = textlabel2.Text.Substring(start2, length2);
                textlabel2.Text = h;
            }

            else if (str == "⌫" && textlabel.Text.Length == 0)
            {
                textlabel.Text = "";
                textlabel2.Text = "";
            }

            else if (str == ".")
            {
                if (!(textlabel.Text.Contains(".")))
                {
                    textlabel.Text += ".";
                    textlabel2.Text += ".";
                }
            }

            else if (str == "=")
            {

                textlabel.Text = new DataTable().Compute(textlabel2.Text, null).ToString();
                
                if(checkbox1.IsChecked==false) {
                    string l = textlabel2.Text + "=" + textlabel.Text;
                    math.Add(l);
                }
                
                
                textlabel2.Text = textlabel.Text;

            }

            else if (!(str == "+" || str == "/" || str == "*" || str == "-")) 
            {
                textlabel.Text += str;
                textlabel2.Text += str;
            }

            else if (str == "+" || str == "/" || str == "*" || str == "-")
            {
                textlabel.Text = "";
                textlabel2.Text += str;
            }


        }

        private void Delete_last(object sender, RoutedEventArgs e)
        {   
            if (math.Count != 0)
                math.RemoveAt(math.Count-1);
        }

        private void Clear_all(object sender, RoutedEventArgs e)
        {
            if (math.Count != 0)
                math.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            checkbox1.Visibility=Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            border1.Visibility = Visibility.Visible;
            mathList.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            checkbox1.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            border1.Visibility = Visibility.Hidden;
            mathList.Visibility = Visibility.Hidden;
        }

        
    }
}
