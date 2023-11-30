using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл для копирования",
                Filter = "Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = filePathTextBox.Text.Trim();
            string destinationFolderPath = destinationFolderTextBox.Text.Trim();
            string newFileName = newFileNameTextBox.Text.Trim();

            // Проверка существования исходного файла
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Выбранный файл не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка существования целевой папки
            if (!Directory.Exists(destinationFolderPath))
            {
                MessageBox.Show("Выбранная целевая папка не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string destinationPath = System.IO.Path.Combine(destinationFolderPath, string.IsNullOrEmpty(newFileName) ? System.IO.Path.GetFileName(sourceFilePath) : newFileName);

                // Проверка, не существует ли уже файл с таким именем в целевой папке
                if (File.Exists(destinationPath))
                {
                    MessageBox.Show("Файл с таким именем уже существует в целевой папке.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Копирование файла
                File.Copy(sourceFilePath, destinationPath);
                MessageBox.Show("Файл успешно скопирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при копировании файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
