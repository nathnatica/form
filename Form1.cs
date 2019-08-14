using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Dao dao = new Dao();

        public Form1()
        {
            InitializeComponent();
            this.button1.Click += this.Button1_Click;
            this.button2.Click += this.ThreeAddClick;
            this.button3.Click += this.ThreeGetClick;
            this.rebuild.Click += this.Rebuild;
        }
        private void ThreeAddClick(object sender, EventArgs e)
        {
            ArrayList array = new ArrayList();
            string[] lines = File.ReadAllLines("C:\\TEMP\\1.txt");
            foreach (string line in lines)
            {
                string[] sp = line.Split('\t');
                Candle three = new Candle();
                three.code = sp[0];
                three.date = Int32.Parse(sp[1]);
                three.time = Int32.Parse(sp[2]);
                three.startprice = Int32.Parse(sp[3]);
                three.endprice = Int32.Parse(sp[4]);
                three.highprice = Int32.Parse(sp[5]);
                three.lowprice = Int32.Parse(sp[6]);
                three.volume = Int32.Parse(sp[7]);
                array.Add(three);
            }
            dao.InsertThreeData(array);
        }

        private void UpdateAvgData(string code, int startDate, int endDate)
        {
            ThreeData d = GetThreeData(code, startDate, 2);
            d.print(); // TODO for check
            if (d.array != null)
            {
                dao.InsertThreeData(new ArrayList(d.array));
                if (d.endDate != 0 && d.startDate != d.endDate && d.endDate <= endDate)
                {
                    UpdateAvgData(code, d.endDate, endDate);
                }
            }
        }

        private void ThreeGetClick(object sender, EventArgs e)
        {
            ThreeData d = GetThreeData("0001", 20180814, 2);
            //ThreeData d = this.GetThreeData("0001", Int32.Parse(this.textBox1.Text), Int32.Parse(this.textBox2.Text));
            d.print(); // TODO for check

            Orders orders = new Orders();
            Check.ThreeDataCheck(d, orders);
            orders.Evaluate();
        }

        private void Rebuild(object sender, EventArgs e)
        {
            this.UpdateAvgData("0001", Int32.Parse(this.textBox1.Text), Int32.Parse(this.textBox2.Text));
            this.UpdateAvgData("0001", Int32.Parse("20190814"), Int32.Parse("2"));
        }

        private ThreeData GetThreeData(string code, int date, int dayCount)
        {
            ThreeData d = new ThreeData();
            Candle[] dbData = dao.GetThreeDataFromDB(code, date, dayCount);
            if (dbData != null && dbData.Length > 0)
            {
                d.AddThreeArray(dbData);
                d.CreateAvgData(0);
            }
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
