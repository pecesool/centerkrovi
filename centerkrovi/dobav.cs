using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace centerkrovi
{
    public partial class dobav : Form
    {
        public dobav()
        {
            InitializeComponent();
        }

        private void dobav_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database3DataSet1.донор". При необходимости она может быть перемещена или удалена.
            this.донорTableAdapter.Fill(this.database3DataSet1.донор);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }//загрузка изображение из файлов
        }

        private void button3_Click(object sender, EventArgs e)
        {
            донорTableAdapter.Adapter.Update(database3DataSet1.донор);
            database3DataSet1.Tables[0].AcceptChanges();
            dataGridView1.Refresh();
            main s = new main();
            s.Show();
            this.Hide();//сохранение и переход на другую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res;
            int b=Convert.ToInt32(comboBox1.Text);
            
            if (comboBox2.Text == "есть") { res = true; } else { res = false; }
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                DataRow nRow = database3DataSet1.Tables[0].NewRow();
                int rc = dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = textBox1.Text;
                nRow[2] = textBox2.Text;
                nRow[3] = b;
                nRow[4] = img;
                nRow[5] = dateTimePicker1.Value;
                nRow[6] = res;
                database3DataSet1.Tables[0].Rows.Add(nRow);

                донорTableAdapter.Adapter.Update(database3DataSet1.донор);
                database3DataSet1.Tables[0].AcceptChanges();
                dataGridView1.Refresh();//сохранение записи
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
