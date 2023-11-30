using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace ExpertSystem_разработка_кода_17_лаба_
{
    public class ExpertSystemCore
    {
        private ExpertSystemData data;
        private IExpertSystemForm form;
        public ExpertSystemCore(ExpertSystemForm app_form)
        {
            data = new ExpertSystemData();
            form = new ExpertSystemWindowsForm();
            (form as ExpertSystemWindowsForm).form = app_form;
            FFileName = "";
        }
        public void AddProposition()
        {
            Proposition prop = new Proposition();
            prop.caption = "Тест";
            prop.itis = true;
            data.propositions.Add(prop);
            form.draw_propositions(data.propositions);
        }

         /// <summary>
         /// Скрытое имя файла
        /// </summary>
        private string FFileName;
        /// <summary>
        /// Имя файла, открытого в данный момент
        /// </summary>
        public string FileName
        {
            get
            {
                return FFileName;
            }
        }
        
        private void UpdateForm()
        {
            form.Caption = FileName;
        }

        /// <summary>
        /// Открыть файл экспертной системы
        /// </summary>
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Открыть проект...";
            openFileDialog.Filter = "Файлы экспертных систем | *.es | Все файлы | *.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                data = (ExpertSystemData)formatter.Deserialize(fs);
                fs.Close();
                FFileName = openFileDialog.FileName;
                UpdateForm();
                form.draw_propositions(data.propositions);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Сохранить файл экспертной системы
        /// </summary>
        public void Save()
        {
            //Если имя файла не задано то вызываем диалог выбора файла
        if (FFileName == "")

        {
                SaveAs();
                return;
            }
            FileStream fs = new FileStream(FFileName, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
            fs.Close();
            UpdateForm();
        }
        /// <summary>
        /// Сохранить файл экспертной системы с диалогом выбора файла
        /// </summary>
        public void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранение проекта...";
            saveFileDialog.Filter = "Файлы экспертных систем | *.es | Все файлы | *.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            FFileName = saveFileDialog.FileName;
            Save();
        }
    }
}
