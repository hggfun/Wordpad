using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Peergrade4
{
    /// <summary>
    /// Класс, содержащий основную форму.
    /// </summary>
    public partial class Form1 : Form
    {
        //Объявляем глобальные переменные.
        public string filename = "";
        public bool saved = true;
        public int fontSize = 8;
        public string fontType = "Times New Roman";
        public FontStyle fontStyle = FontStyle.Regular;
        public Form2 form2;
        public Form3 form3;
        public int time = 100;
        public int color = 1;

        /// <summary>
        /// Инициализируем содержание формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Создаем новую вкладку.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает выбранный файл.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            try
            {
                StreamReader a = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = a.ReadToEnd();
                filename = openFileDialog1.FileName;
                a.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось открыть файл");
            }
        }

        /// <summary>
        /// Сохраняем файл по пути по умолчанию.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string t;
                if (filename == "")
                {
                    filename = "Файл.txt";
                }
                StreamWriter b = new StreamWriter(filename);
                b.Write(richTextBox1.Text);
                t = Path.GetFullPath(filename);
                b.Close();
                MessageBox.Show("Файл сохранен по пути по умолчанию:\n" + t);
                saved = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не сохранен");
            }
        }

        /// <summary>
        /// Сохраняем по выбранному пути.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filename = "";
                string t;
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;
                StreamWriter b = new StreamWriter(filename);
                b.Write(richTextBox1.Text);
                t = Path.GetFullPath(filename);
                b.Close();
                MessageBox.Show("Файл сохранен по пути:\n" + t);
                saved = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не сохранен");
            }
        }

        /// <summary>
        /// Копируем выделенный текст в буфер обмена.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Вырезаем выделенный текст.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.SelectionLength));
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Выделяем все содержимое текст бокса.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void chooseEverythingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        /// <summary>
        /// Вызываем форму для определения настроек шрифта.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

        /// <summary>
        /// Фиксируем изменения текста.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void Changed(object sender, EventArgs e)
        {
            saved = false;
        }

        /// <summary>
        /// Предлагает сохранить файл, если он не сохранен на момент закрытия формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void SaveIfUnsaved(object sender, FormClosingEventArgs e)
        {
            if (saved == false)
            {
                DialogResult res = MessageBox.Show("Сохранить изменения?", "Файл не сохранен", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        filename = "";
                        string t;
                        saveFileDialog1.ShowDialog();
                        filename = saveFileDialog1.FileName;
                        StreamWriter b = new StreamWriter(filename);
                        b.Write(richTextBox1.Text);
                        t = Path.GetFullPath(filename);
                        b.Close();
                        MessageBox.Show("Файл сохранен по пути:\n" + t);
                        saved = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Файл не сохранен");
                    }
                }
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Вставляет содержимое буфера обмена на место вызова.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart) + Clipboard.GetText() + richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.Text.Length - richTextBox1.SelectionStart);
        }

        /// <summary>
        /// Метод, отрабатывающий при начале использования основной формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void First(object sender, EventArgs e)
        {
            if (form2 != null)
            {
                fontSize = form2.fontSize;
                fontType = form2.fontType;
                fontStyle = form2.fontStyle;
                richTextBox1.SelectionFont = new Font(fontType, fontSize, fontStyle);
            }
            if (form3 != null)
            {
                time = form3.time;
                if (form3.color != 0)
                {
                    color = form3.color;
                }
                if (color % 2 == 1)
                {
                    richTextBox1.BackColor = Color.White;
                }
                if (color % 2 == 0)
                {
                    richTextBox1.BackColor = Color.Blue;
                }
                timer1.Interval = time;
            }
        }

        /// <summary>
        /// Открывает форму настроек.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.Show();
        }

        /// <summary>
        /// Автосохранение файла. К этому методу обращается таймер.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void Autosave(object sender, EventArgs e)
        {
            //MessageBox.Show("Ок?","Ок");
            try
            {
                string t;
                if (filename == "")
                {
                    filename = "Файл";
                }
                StreamWriter b = new StreamWriter(filename);
                b.Write(richTextBox1.Text);
                t = Path.GetFullPath(filename);
                b.Close();
                saved = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Для вырвиглазного режима. Надеюсь уже успел им насладиться. К этому методу обращается второй таймер каждые 0.01 секунду.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void ColorChange(object sender, EventArgs e)
        {
            if (richTextBox1.BackColor == Color.Blue)
            {
                richTextBox1.BackColor = Color.Red;
                return;
            }
            if (richTextBox1.BackColor == Color.Red)
            {
                richTextBox1.BackColor = Color.Blue;
            }
        }

        /// <summary>
        /// Сохраняет файл с расширением rtf.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void saveRtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filename = "";
                string t;
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName+".rtf";
                if (filename == ".rtf")
                {
                    throw new ArgumentException();
                }
                richTextBox1.SaveFile(filename);
                t = Path.GetFullPath(filename);
                MessageBox.Show("Файл сохранен по пути:\n" + t);
                saved = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не сохранен");
            }
        }

        /// <summary>
        /// Сохраняет файл с разрешением txt.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void saveTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filename = "";
                string t;
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName + ".txt";
                if (filename == ".txt")
                {
                    throw new ArgumentException();
                }
                richTextBox1.SaveFile(filename);
                t = Path.GetFullPath(filename);
                MessageBox.Show("Файл сохранен по пути:\n" + t);
                saved = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не сохранен");
            }
        }

        /// <summary>
        /// Вызывает контекстное меню по нажатию правой кнопки мыши.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void MouseLeft(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }
    }
}
