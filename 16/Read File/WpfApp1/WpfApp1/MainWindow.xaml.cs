using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    Encoding encoding = GetSelectedEncoding();

                    // Чтение текста из файла с выбранной кодировкой
                    string fileContent = File.ReadAllText(filePath, encoding);
                    FileContentTextBlock.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Encoding GetSelectedEncoding()
        {
            switch (EncodingComboBox.SelectedIndex)
            {
                case 0:
                    return Encoding.UTF8;
                case 1:
                    return Encoding.GetEncoding(1251); // Win1251
                case 2:
                    return Encoding.GetEncoding(866); // DOS 866
                default:
                    return Encoding.UTF8;
            }
        }
    }
}
