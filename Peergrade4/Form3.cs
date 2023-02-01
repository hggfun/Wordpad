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
    /// Форма настроек.
    /// </summary>
    public partial class Form3 : Form
    {
        //Объявляем глобальные переменные.
        public int time = 100;
        public int color;

        /// <summary>
        /// Инициализируем форму.
        /// </summary>
        public Form3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загружаем форму.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Меню выбора частоты обновления автосохранения.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            time = int.Parse(comboBox1.SelectedItem.ToString());
        }

        /// <summary>
        /// Кнопка выбора цветового режима.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            color =  1;
        }

        /// <summary>
        /// Кнопка выбора цветового режима.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            color = 2;
        }

        /// <summary>
        /// Кнопка завершения пользования формой.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// А это просто надпись.
        /// </summary>
        /// <param name="sender">Объект, вызвавший метод.</param>
        /// <param name="e">Содержит дополнительную информацию.</param>
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
