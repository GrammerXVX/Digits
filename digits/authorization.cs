using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Data.SqlClient;

namespace digits
{
    
    public partial class authorization : Form
    {
        SqlCommand command = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public authorization()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registration reg = new registration();
            reg.Show();
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            textBox_name.MaxLength = 50;
            textBox_pass.MaxLength = 50;
        }

        private void button_auto_Click(object sender, EventArgs e)
        {
            Users.loginUser = textBox_name.Text;
            Users.passUser= textBox_pass.Text;
            //var loginUser = textBox_name.Text;
            //var passUser = textBox_pass.Text;
            string queryString = $"Select name,password from Users where name='{Users.loginUser}' and password='{Users.passUser}'";
            command = new SqlCommand(queryString, DataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                this.Hide();
                MessageBox.Show("Вы успешно вошли");
                Form1 user_panel = new Form1();
                user_panel.Show();
            }
            else
            {
                MessageBox.Show("Введенные вами данные отсутствуют");
            }
        }

        private void checkBox_pas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pas.Checked)
            {
                textBox_pass.PasswordChar = '*';
                checkBox_pas.Text = "Скрыть пароль";
            }
            else
            {
                checkBox_pas.Text = "Показать пароль";
                textBox_pass.PasswordChar = '\0';
            }
        }
    }
}
