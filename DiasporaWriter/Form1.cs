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

namespace DiasporaWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; //фильтр для сохранения файла
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; //фильтр для открытия файла
            fontDialog1.ShowColor = true;
            colorDialog1.FullOpen = true;
            colorDialog1.Color = this.BackColor;
            Timer timer = new Timer(); //время на панели
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer1_Tick);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            information Form2 = new information(); //открыть другое окно
            Form2.Show();
            //this.Hide();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //счетик вводимых символов
        {
            toolStripLabel2.Text = textBox1.Text.Length.ToString();


        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e) //выбор шрифта и его размера
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Font = fontDialog1.Font;


        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) //сохранить файл
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) //открыть файл
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        private void сменитьЦветШрифтаToolStripMenuItem_Click(object sender, EventArgs e) //смена цвета шрифта
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.ForeColor = colorDialog1.Color;
        }

        private void сменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e) //смена цвета фона
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.BackColor = colorDialog1.Color;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel3.Text = DateTime.Now.ToString("yyyy.MM.dd, HH:mm:ss"); //формат даты
        }
    }
}
