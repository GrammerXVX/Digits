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
    public partial class registration : Form
    {
        SqlCommand command = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public registration()
        {
            InitializeComponent();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            authorization auto = new authorization();
            auto.Show();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            textBox_name.MaxLength = 50;
            textBox_pass.MaxLength = 50;
        }

        private void button_reg_Click(object sender, EventArgs e)
        {

             DataBase.OpenConnection();
            if (CheckUser())
            {
                return;
            }          
            var loginUser = textBox_name.Text;
            var passUser = textBox_pass.Text;
            string querryString1 = $"INSERT INTO [Users](name,password) VALUES ('{loginUser}','{passUser}')";
            command = new SqlCommand(querryString1, DataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Вы зарегистрировались");
            this.Hide();
            authorization auto = new authorization();
            auto.Show();
        }
        private Boolean CheckUser()
        {
            var loginUser = textBox_name.Text;
            string queryString = $"Select name from [Users] where name='{loginUser}'";
            command = new SqlCommand(queryString, DataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
               
                MessageBox.Show("Пользователь существует");
                return true;
             

            }
            else 
            {
                MessageBox.Show("Введенные вами данные отсутствуют");
                return false;
            }

        }
    }
}
