using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace centerkrovi
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database3DataSet1.донор". При необходимости она может быть перемещена или удалена.
            this.донорTableAdapter.Fill(this.database3DataSet1.донор);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int res=0;
            int b = Convert.ToInt32(textBox5.Text);
            if (comboBox3.Text == "1") { res = 10000*b; }
            if (comboBox3.Text == "2") { res = 12000*b; }
            if (comboBox3.Text == "3") { res = 10000*b; }
            if (comboBox3.Text == "4") { res = 12000*b; }
            if (comboBox4.Text == "есть") { res = res - 5000; }
            label12.Text = "Препологаемая цена крови " + res.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[1].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            k++;
                            break;//поиск по базе данных
                        }
                    }
                }
            }
            label3.Text = "Найдено " + k.ToString() + " Совпадений";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            label3.Text = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool res;
            if (comboBox2.Text == "есть") { res = true; } else { res = false; }
            int k = 0;
            string poisk = "";
            if (textBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Имя] LIKE'%" + textBox1.Text + "%'";
            }
            if (textBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Фамилия] LIKE'%" + textBox2.Text + "%'";
            }
            if (comboBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Группа крови]=" + Convert.ToInt32(comboBox1.Text);
            }

            if (comboBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                if (res == true)
                {
                    poisk += донорBindingSource.Filter = "[Вредные привычки] = 1";
                }
                else { poisk += донорBindingSource.Filter = "[Вредные привычки] = 0"; }
            }
            if (k >= 1)
            {
                донорBindingSource.Filter = poisk;//фильрация по нескольким полям

            }
            else
            {
                if (k == 0)
                {
                    донорBindingSource.Filter = "";//сброс фильтрации
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            донорBindingSource.Filter = null;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";//сброс фильра
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = 1;
            if (radioButton4.Checked == true) { x = 0; }
            if (radioButton3.Checked == true) { x = 1; }
            if (checkBox6.Checked == true) { if (x == 0) { донорBindingSource.Sort = "Имя ASC"; } else { донорBindingSource.Sort = "Имя DESC"; } }
            if (checkBox2.Checked == true) { if (x == 0) { донорBindingSource.Sort = "Фамилия ASC"; } else { донорBindingSource.Sort = "Фамилия DESC"; } }
            if (checkBox5.Checked == true) { if (x == 0) { донорBindingSource.Sort = "Группа крови ASC"; } else { донорBindingSource.Sort = "Группа крови DESC"; } }
            if (checkBox1.Checked == true) { if (x == 0) { донорBindingSource.Sort = "Вредные привычки ASC"; } else { донорBindingSource.Sort = "Вредные привычки DESC"; } }
            //сортировка по нескольким полям
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dobav s = new dobav();
            s.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox6.Checked = false;
            checkBox5.Checked = false;
        }
    }
}
