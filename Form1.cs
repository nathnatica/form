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

        Dao dao = new Dao();

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

            Candle three = new Candle();
            three.code = "0001";
            three.date = date;
            three.time = time;
            three.startprice = 1;
            three.endprice = 1;
            three.highprice = 1;
            three.lowprice = 1;
            three.volume = 1;


            dao.InsertThreeData(three);

            time += 1;
            if (time >= 6)
            {
                date += 1;
                time = 1;
            }
        }

        private void ThreeGetClick(object sender, EventArgs e)
        {
            ThreeData d = this.GetThreeData("0001", Int32.Parse(this.textBox1.Text), Int32.Parse(this.textBox2.Text));
            Orders orders = new Orders();
            Check.ThreeDataCheck(d, orders);
            orders.Evaluate();
        }


        private ThreeData GetThreeData(string code, int date, int dayCount)
        {
            Candle[] dbData = dao.GetThreeDataFromDB(code, date, dayCount);
            ThreeData d = new ThreeData();
            d.AddThreeArray(dbData);
            d.CreateAvgData(0);
            return d;
        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //this is my insert query in which i am taking input from the user through windows forms  
            //    string query = "insert into day(code, no, date, end_price) " +
            //        "select * from (select '0001', (select ifnull(max(no),0)+1 from day where code = '0001'), " +
            //        date +
            //        ", " +
            //        price +
            //        ") as tmp where not exists (select date from day where code = '0001' and date = " +
            //        date +
            //        ");";
            //    //this is command class which will handle the query and connection object.
            //    mysqlconnection myconn2 = getconnection();
            //    mysqlcommand mycommand2 = new mysqlcommand(query, myconn2);
            //    mysqldatareader myreader2;
            //    myconn2.open();
            //    myreader2 = mycommand2.executereader();     // here our query will be executed and data saved into the database.  
            //    while (myreader2.read())
            //    {
            //    }
            //    myconn2.close();

            //    date += 1; // todo
            //    price += new random().next(-10, 11); // todo //}
            //catch (exception ex)
            //{
            //    messagebox.show(ex.message);
            //}
        }

    }
}
