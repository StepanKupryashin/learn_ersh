using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\", // Установите начальный путь по умолчанию
                Title = "Выберите папку для анализа",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Выберите папку"
            };

            if (folderDialog.ShowDialog() == true)
            {
                folderPathTextBox.Text = Path.GetDirectoryName(folderDialog.FileName);
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = folderPathTextBox.Text.Trim();

            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Укажите существующую папку для анализа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Получение всех файлов в указанной папке
                var files = Directory.GetFiles(folderPath);

                // Извлечение расширений файлов
                var extensions = files.Select(Path.GetExtension);

                // Группировка расширений и подсчет их количества
                var extensionCounts = extensions.GroupBy(ext => ext)
                                               .Select(group => new { Extension = group.Key, Count = group.Count() })
                                               .OrderByDescending(x => x.Count)
                                               .Take(5)
                                               .ToList();

                // Отображение результатов в ListBox
                extensionsListBox.Items.Clear();
                foreach (var extensionCount in extensionCounts)
                {
                    extensionsListBox.Items.Add($"{extensionCount.Extension}: {extensionCount.Count} файлов");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при анализе папки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
