using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  //Its for MySQL

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int date = 1;
        int price = 1000;

        public Form1()
        {
            InitializeComponent();
            this.button1.Click += this.Button1_Click;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=qkrtjdgh;database=testdb";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into day(code, no, date, end_price) " +
                    "select * from (select '0001', (select ifnull(max(no),0)+1 from day where code = '0001'), " +
                    date +
                    ", " +
                    price +
                    ") as tmp where not exists (select date from day where code = '0001' and date = " +
                    date +
                    ");";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                //MessageBox.Show("Save Data");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();

                date += 1;
                price += new Random().Next(-10, 11);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
