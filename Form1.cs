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
        int time = 1;
        int price = 1000;

        public Form1()
        {
            InitializeComponent();
            this.button1.Click += this.Button1_Click;
            this.button2.Click += this.ThreeAddClick;
            this.button3.Click += this.ThreeGetClick;
        }
        private void ThreeAddClick(object sender, EventArgs e)
        {
            price += new Random().Next(-10, 11);

            this.InsertThreeData("0001", date, time, 0, price, 0, 0, 0);

            time += 1;
            if (time >= 6)
            {
                date += 1;
                time = 1;
            }
        }

        private void ThreeGetClick(object sender, EventArgs e)
        {
            this.GetThreeData("0001", Int32.Parse(this.textBox1.Text), Int32.Parse(this.textBox2.Text));
        }

        private void GetThreeData(string code, int date, int dayCount)
        {
            try
            {
                string Query = "select date, time from three where code=@val1 and date <= @val2 order by date desc, time desc limit @val3;";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                cmd.Parameters.AddWithValue("@val1", code);
                cmd.Parameters.AddWithValue("@val2", date);
                cmd.Parameters.AddWithValue("@val3", dayCount);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();  
                while (MyReader2.Read())
                {
                    System.Console.WriteLine(MyReader2.GetInt32(0) + " - " + MyReader2.GetInt32(1));
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {

            }

                Three[] threeArray = new Three[100];

            for (int i=0; i < threeArray.Length; i++)
            {
                Three entity = new Three();
                threeArray[i] = entity;
            }
        }


        
        private void InsertThreeData(string code, int date, int time, int startPrice, int endPrice, int highPrice, int lowPrice, int volume)
        {
            try
            {  
                string Query = "insert into three(code, date, time, start_price, end_price, high_price, low_price, volumn) " +
                    "select @val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8 as tmp " +
                    "where not exists (select 'x' from three where code = @val1 and date = @val2 and time = @val3);";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                cmd.Parameters.AddWithValue("@val1", code);
                cmd.Parameters.AddWithValue("@val2", date);
                cmd.Parameters.AddWithValue("@val3", time);
                cmd.Parameters.AddWithValue("@val4", startPrice);
                cmd.Parameters.AddWithValue("@val5", endPrice);
                cmd.Parameters.AddWithValue("@val6", highPrice);
                cmd.Parameters.AddWithValue("@val7", lowPrice);
                cmd.Parameters.AddWithValue("@val8", volume);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private MySqlConnection GetConnection()
        {
            string str = "datasource=localhost;port=3306;username=root;password=qkrtjdgh;database=testdb";
            return new MySqlConnection(str);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into day(code, no, date, end_price) " +
                    "select * from (select '0001', (select ifnull(max(no),0)+1 from day where code = '0001'), " +
                    date +
                    ", " +
                    price +
                    ") as tmp where not exists (select date from day where code = '0001' and date = " +
                    date +
                    ");";
                //This is command class which will handle the query and connection object.
                MySqlConnection MyConn2 = GetConnection();
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

    public class Three
    {
        int date;
        int time;
        int startprice;
        int endprice;
        int highprice;
        int lowprice;
        int volume;

        int avg5;
        int avg20;
        int avg120;
    }
}
