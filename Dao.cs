using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Dao
    {
        public MySqlConnection GetConnection()
        {
            string str = "datasource=localhost;port=3306;username=root;password=qkrtjdgh;database=testdb";
            return new MySqlConnection(str);
        }

        public Candle[] GetThreeDataFromDB(string code, int date, int dayCount)
        {

            // if dayCount == 1 then realtime
            // use offset(120) to idx when set to threeArray


            Candle[] threeArray = new Candle[120 * dayCount];
            try
            {
                string Query = "select date, time, start_price, end_price, high_price, low_price, volumn, avg_5, avg_20, avg_120 from three where code=@val1 and date <= @val2 order by date desc, time desc limit @val3;";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                cmd.Parameters.AddWithValue("@val1", code);
                cmd.Parameters.AddWithValue("@val2", date);
                cmd.Parameters.AddWithValue("@val3", dayCount);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();

                int i = 0;
                while (MyReader2.Read())
                {
                    Console.WriteLine(MyReader2.GetInt32(0) + " - " + MyReader2.GetInt32(1));
                    Candle entity = new Candle();
                    entity.date = MyReader2.GetInt32(0);
                    entity.time = MyReader2.GetInt32(1);
                    entity.startprice = MyReader2.GetInt32(2);
                    entity.endprice = MyReader2.GetInt32(3);
                    entity.highprice = MyReader2.GetInt32(4);
                    entity.lowprice = MyReader2.GetInt32(5);
                    entity.volume = MyReader2.GetInt32(6);
                    entity.avg5 = MyReader2.GetInt32(7);
                    entity.avg20 = MyReader2.GetInt32(8);
                    entity.avg120 = MyReader2.GetInt32(9);
                    threeArray[i] = entity;
                    i += 1;
                }
                MyConn2.Close();
            }
            catch (Exception)
            {
            }

            Array.Reverse(threeArray);
            return threeArray;
        }

        public void InsertThreeData(Candle data)
        {
            try
            {
                string Query = "insert into three(code, date, time, start_price, end_price, high_price, low_price, volumn, avg_5, avg_20, avg_120 ) " +
                    "select @val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10, @val11 as tmp " +
                    "where not exists (select 'x' from three where code = @val1 and date = @val2 and time = @val3);";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                cmd.Parameters.AddWithValue("@val1", data.code);
                cmd.Parameters.AddWithValue("@val2", data.date);
                cmd.Parameters.AddWithValue("@val3", data.time);
                cmd.Parameters.AddWithValue("@val4", data.startprice);
                cmd.Parameters.AddWithValue("@val5", data.endprice);
                cmd.Parameters.AddWithValue("@val6", data.highprice);
                cmd.Parameters.AddWithValue("@val7", data.lowprice);
                cmd.Parameters.AddWithValue("@val8", data.volume);
                cmd.Parameters.AddWithValue("@val9", data.avg5);
                cmd.Parameters.AddWithValue("@val10", data.avg20);
                cmd.Parameters.AddWithValue("@val11", data.avg120);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                    // ???
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public int GetNextSeq()
        {
            int seq = 1;
            try
            {
                string Query = "select ifnull(max(seq),0)+1 from evaluate;";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                    seq = MyReader2.GetInt32(0);
                }
                MyConn2.Close();
            }
            catch (Exception)
            {
            }

            return seq;
        }
    }
}
