using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchFilesButton_Click(object sender, RoutedEventArgs e)
        {
            // Используем диалоговое окно выбора папки для получения директории
            var folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Выберите папку для поиска файлов"
            };

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Очистка списка результатов при новом поиске
                resultListBox.Items.Clear();

                // Получение ключевого слова из текстового поля
                string keyword = keywordTextBox.Text.Trim();

                // Получение пути к выбранной пользователем папке
                string searchFolder = folderDialog.FileName;

                // Вызов метода для поиска файлов
                List<string> foundFiles = SearchFiles(searchFolder, keyword);

                // Отображение результатов в ListBox
                foreach (string file in foundFiles)
                {
                    resultListBox.Items.Add(file);
                }
            }
        }

        private List<string> SearchFiles(string folder, string keyword)
        {
            List<string> foundFiles = new List<string>();

            try
            {
                // Получение всех файлов в текущей папке
                string[] files = Directory.GetFiles(folder);

                // Поиск файлов, содержащих ключевое слово в названии
                foreach (string file in files)
                {
                    if (System.IO.Path.GetFileName(file).Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        foundFiles.Add(file);
                    }
                }

                // Рекурсивный вызов для подпапок
                string[] subdirectories = Directory.GetDirectories(folder);
                foreach (string subdirectory in subdirectories)
                {
                    foundFiles.AddRange(SearchFiles(subdirectory, keyword));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске файлов: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return foundFiles;
        }
    }
}
