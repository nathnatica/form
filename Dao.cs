using System;
using System.Collections;
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
            // use offset(129) to idx when set to threeArray

            Candle[] threeArray = new Candle[Constants.DAY_CANDLE_COUNT * dayCount];
            try
            {
                string Query = "select date, time, start_price, end_price, high_price, low_price, volumn, avg_5, avg_20, avg_120 from three where code=@val1 and date >= @val2 order by date asc, time asc limit @val3;";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                cmd.Parameters.AddWithValue("@val1", code);
                cmd.Parameters.AddWithValue("@val2", date);
                cmd.Parameters.AddWithValue("@val3", Constants.DAY_CANDLE_COUNT * dayCount);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();

                int i = 0;
                while (MyReader2.Read())
                {
                    Candle entity = new Candle();
                    entity.code = code;
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
            catch (Exception e)
            {
                Console.Write(e);
            }

            return threeArray;
        }

        public List<Item> GetItemData()
        {
            List<Item> array = new List<Item>();
            try
            {
                string Query = "select code, name, target, status, day_start_date, day_end_date, min_start_date, min_end_date, day_avg_start_date, day_avg_end_date, min_avg_start_date, min_avg_end_date, upd_date, type " +
                    "from item order by target asc, upd_date desc;";
                MySqlConnection MyConn2 = GetConnection();
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = cmd.ExecuteReader();

                while (MyReader2.Read())
                {
                    Item entity = new Item();
                    entity.code = MyReader2.GetString(0);
                    entity.name = MyReader2.GetString(1);
                    entity.target = MyReader2.GetString(2);
                    entity.status = MyReader2.GetString(3);
                    entity.dayStartDate = Util.GetNotNullInT(4, MyReader2);
                    entity.dayEndDate = Util.GetNotNullInT(5, MyReader2);
                    entity.minStartDate = Util.GetNotNullInT(6, MyReader2);
                    entity.minEndDate = Util.GetNotNullInT(7, MyReader2);
                    entity.dayAvgStartDate = Util.GetNotNullInT(8, MyReader2);
                    entity.dayAvgEndDate = Util.GetNotNullInT(9, MyReader2);
                    entity.minAvgStartDate = Util.GetNotNullInT(10, MyReader2);
                    entity.minAvgEndDate = Util.GetNotNullInT(11, MyReader2);
                    entity.updDate = Util.GetNotNullInT(12, MyReader2);
                    entity.update = "UPDATE";
                    entity.type = MyReader2.GetString(13);
                    array.Add(entity);
                }
                MyConn2.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return array;
        }

        public void InsertItemData(Item item)
        {
            List<Item> list = new List<Item>();
            list.Add(item);
            InsertItemData(list, false);
        }

        public void InsertItemData(List<Item> array, Boolean insertOnly)
        {
            try
            {
                MySqlConnection MyConn2 = GetConnection();
                MyConn2.Open();
                foreach (Item data in array)
                {
                    string Query = "insert into item (code, name, target, status, day_start_date, day_end_date, min_start_date, min_end_date, day_avg_start_date, day_avg_end_date, min_avg_start_date, min_avg_end_date, upd_date, type) " +
                        "values (@val1, @val2, @val3, @val4, @val5, @val6, now(), @val8, @val9, @val10, @val11, @val12, @val13, @val14) ";
                    if (insertOnly)
                    {
                        Query += "on duplicate key update upd_date = now();";
                    } else
                    {
                        Query += "on duplicate key update target = @val3, status = @val4, day_start_date = @val5, day_end_date = @val6, upd_date = now(), " +
                        "min_start_date = @val8, min_end_date = @val9, day_avg_start_date = @val10, day_avg_end_date = @val11, min_avg_start_date = @val12, min_avg_end_date = @val13, type = @val14;";
                    }
                    MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                    cmd.Parameters.AddWithValue("@val1", data.code);
                    cmd.Parameters.AddWithValue("@val2", data.name);
                    cmd.Parameters.AddWithValue("@val3", data.target);
                    cmd.Parameters.AddWithValue("@val4", data.status);
                    cmd.Parameters.AddWithValue("@val5", data.dayStartDate);
                    cmd.Parameters.AddWithValue("@val6", data.dayEndDate);
                    cmd.Parameters.AddWithValue("@val8", data.minStartDate);
                    cmd.Parameters.AddWithValue("@val9", data.minEndDate);
                    cmd.Parameters.AddWithValue("@val10", data.dayAvgStartDate);
                    cmd.Parameters.AddWithValue("@val11", data.dayAvgEndDate);
                    cmd.Parameters.AddWithValue("@val12", data.minAvgStartDate);
                    cmd.Parameters.AddWithValue("@val13", data.minAvgEndDate);
                    cmd.Parameters.AddWithValue("@val14", data.type);
                    MySqlDataReader MyReader2;
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                }
                MyConn2.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        public void InsertDayData(List<Candle> array)
        {
            try
            {
                MySqlConnection MyConn2 = GetConnection();
                MyConn2.Open();
                foreach (Candle data in array)
                {
                    string Query = "insert into day (code, date, start_price, end_price, high_price, low_price, volume, avg_5, avg_20, avg_120)" +
                        " values (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10)" +
                        " on duplicate key update avg_5 = @val8, avg_20 = @val9, avg_120 = @val10";
                    MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                    cmd.Parameters.AddWithValue("@val1", data.code);
                    cmd.Parameters.AddWithValue("@val2", data.date);
                    cmd.Parameters.AddWithValue("@val3", data.startprice);
                    cmd.Parameters.AddWithValue("@val4", data.endprice);
                    cmd.Parameters.AddWithValue("@val5", data.highprice);
                    cmd.Parameters.AddWithValue("@val6", data.lowprice);
                    cmd.Parameters.AddWithValue("@val7", data.volume);
                    cmd.Parameters.AddWithValue("@val8", data.avg5);
                    cmd.Parameters.AddWithValue("@val9", data.avg20);
                    cmd.Parameters.AddWithValue("@val10", data.avg120);
                    MySqlDataReader MyReader2;
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                }
                MyConn2.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        public void InsertThreeData(ArrayList array)
        {
            try
            {
                MySqlConnection MyConn2 = GetConnection();
                MyConn2.Open();
                foreach (Candle data in array)
                {
                    string Query = "insert into three(code, date, time, start_price, end_price, high_price, low_price, volumn, avg_5, avg_20, avg_120 )" +
                        " values (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10, @val11)" +
                        " on duplicate key update avg_5 = @val9, avg_20 = @val10, avg_120 = @val11";
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
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                }
                MyConn2.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        public void InsertEvaluateData(ArrayList array)
        {
            try
            {
                MySqlConnection MyConn2 = GetConnection();
                MyConn2.Open();
                foreach (Orders data in array)
                {
                    string Query = "insert into evaluate(date, rule, check_total, check_matched, win_count, lose_count, match_rate, winning_rate, total_profit_rate)" +
                        " values (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9)";
                    MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                    cmd.Parameters.AddWithValue("@val1", data.date);
                    cmd.Parameters.AddWithValue("@val2", data.rule);
                    cmd.Parameters.AddWithValue("@val3", data.checkTotal);
                    cmd.Parameters.AddWithValue("@val4", data.winCount + data.loseCount);
                    cmd.Parameters.AddWithValue("@val5", data.winCount);
                    cmd.Parameters.AddWithValue("@val6", data.loseCount);
                    cmd.Parameters.AddWithValue("@val7", data.GetMatchRate());
                    cmd.Parameters.AddWithValue("@val8", data.GetWinningRate());
                    cmd.Parameters.AddWithValue("@val9", data.GetTotalProfitRate());
                    MySqlDataReader MyReader2;
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                }
                MyConn2.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
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
            catch (Exception e)
            {
                Console.Write(e);
            }

            return seq;
        }
    }
}
