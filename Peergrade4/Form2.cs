using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peergrade4
{
    /// <summary>
    /// Форма настройки шрифта.
    /// </summary>
    public partial class Form2 : Form
    {
        //
        public int fontSize = 8;
        public string fontType = "Times New Roman";
        public FontStyle fontStyle = FontStyle.Regular;

        /// <summary>
        /// Инициализируем форму.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Меню выбора размера шрифта.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontSize = int.Parse(comboBox1.SelectedItem.ToString());
        }

        /// <summary>
        /// Меню выбора шрифта.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontType = comboBox2.SelectedItem.ToString();
        }

        /// <summary>
        /// Меню выбора стиля шрифта.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           string fontstyle = comboBox3.SelectedItem.ToString();
            switch (fontstyle)
            {
                case "Обычный":
                    fontStyle = FontStyle.Regular;
                    break;
                case "Курсив":
                    fontStyle = FontStyle.Italic;
                    break;
                case "Жирный":
                    fontStyle = FontStyle.Bold;
                    break;
                case "Подчеркнутый":
                    fontStyle = FontStyle.Underline;
                    break;
                case "Зачеркнутый":
                    fontStyle = FontStyle.Strikeout;
                    break;  
            }
        }

        /// <summary>
        /// Кнопка завершения работы с формой.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
