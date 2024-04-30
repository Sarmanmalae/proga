using System.IO;
using System.Reflection.Emit;
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
using static System.Net.Mime.MediaTypeNames;

namespace ex5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(@"Source"))
            {
                textBox.Text = File.ReadAllText(@"Source");
            }
        }

        private void SaveNotes()
        {
            string[] lines = textBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string textToSave = string.Join(Environment.NewLine, lines);
            File.WriteAllText(@"Source", textToSave);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveNotes();
        }

        private void ComboBox_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = ((ComboBoxItem)comboBox_Color.SelectedItem).Content.ToString();
            switch (selectedColor)
            {
                case "Red":
                    textBox.Background = Brushes.Red;
                    break;
                case "Blue":
                    textBox.Background = Brushes.Blue;
                    break;
                case "Green":
                    textBox.Background = Brushes.Green;
                    break;
                case "Gray":
                    textBox.Background = Brushes.Gray;
                    break;
                case "AliceBlue":
                    textBox.Background = Brushes.AliceBlue;
                    break;
                case "Violet":
                    textBox.Background = Brushes.Violet;
                    break;
            }
        }

        private void ComboBox_Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFont = ((ComboBoxItem)comboBox_Font.SelectedItem).Content.ToString();
            switch (selectedFont)
            {
                case "Arial":
                    textBox.FontFamily = new FontFamily("Arial");
                    break;
                case "Times New Roman":
                    textBox.FontFamily = new FontFamily("Times New Roman");
                    break;
                case "Calibri":
                    textBox.FontFamily = new FontFamily("Calibri");
                    break;
                case "Consolas":
                    textBox.FontFamily = new FontFamily("Consolas");
                    break;
                case "Impact":
                    textBox.FontFamily = new FontFamily("Impact");
                    break;
                case "Gadugi":
                    textBox.FontFamily = new FontFamily("Gadugi");
                    break;
            }
        }

        private void ComboBox_FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFontSize = ((ComboBoxItem)comboBox_FontSize.SelectedItem).Content.ToString();
            switch (selectedFontSize)
            {
                case "12":
                    textBox.FontSize = 12;
                    break;
                case "14":
                    textBox.FontSize = 14;
                    break;
                case "16":
                    textBox.FontSize = 16;
                    break;
                case "18":
                    textBox.FontSize = 18;
                    break;
                case "24":
                    textBox.FontSize = 24;
                    break;
                case "36":
                    textBox.FontSize = 36;
                    break;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveNotes();
        }
    }
}