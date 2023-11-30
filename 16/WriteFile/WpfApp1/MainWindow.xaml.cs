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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

using System.IO;



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


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст из TextBox
            string textToSave = TextBox.Text;

            if (string.IsNullOrEmpty(textToSave))
            {
                MessageBox.Show("Введите текст для сохранения.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаем диалоговое окно выбора файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить текстовый файл",
                FileName = "Новый файл.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Получаем путь к выбранному файлу
                    string filePath = saveFileDialog.FileName;

                    // Получаем выбранную кодировку
                    Encoding encoding = GetSelectedEncoding();

                    // Сохраняем текст в файл с выбранной кодировкой
                    File.WriteAllText(filePath, textToSave, encoding);

                    MessageBox.Show($"Файл успешно сохранен по пути:\n{filePath}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Encoding GetSelectedEncoding()
        {
            // Получаем выбранную кодировку из ComboBox
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
