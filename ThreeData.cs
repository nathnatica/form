using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ThreeData
    {
        public Candle[] array;
        public string code;
        public int dayStartIdx;
        public int dayHighPrice;
        public int dayLowPrice = Int32.MaxValue;
        public int startDate;
        public int endDate;
        public int lastIdx;

        public void Print()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("START DATE    : " + startDate);
            Console.WriteLine("END   DATE    : " + endDate);
            Console.WriteLine("DAY START IDX : " + dayStartIdx);
            Console.WriteLine("DAY HIGH      : " + dayHighPrice);
            Console.WriteLine("DAY LOW       : " + dayLowPrice);
            Console.WriteLine("LAST IDX      : " + lastIdx);
            Console.WriteLine("=================================");
        }

        public void AddThreeArray(Candle[] array)
        {
            if (this.array == null || this.array.Length == 0)
            {
                if (array != null && array[0] != null)
                {
                    this.array = array;
                    this.startDate = this.array[0].date;
                    this.code = this.array[0].code;
                }
            }
            else
            {
                int rebuildIdx = 0;
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    Candle t = array[i];
                    int idx = Util.ConvertTimetoIndex(t.time);
                    // need to plus offset for realtime data

                    if (this.array[idx] == null)
                    {
                        this.array[idx] = array[i];
                    }
                    else
                    {
                        this.array[idx] = array[i];
                        rebuildIdx = idx;
                        break;
                    }
                }
                CreateAvgData(rebuildIdx);
            }
        }

        public void CreateAvgData(int startIdx)
        {
            if (this.array == null)
            {
                return;
            }

            for (int i = startIdx; i < this.array.Length -1; i++)
            {
                if (this.array[i] != null)
                {
                    if (i > 0 && this.array[i].date != this.array[i - 1].date)
                    {
                        this.dayStartIdx = i;

                    }

                    this.dayHighPrice = Math.Max(this.dayHighPrice, this.array[i].highprice);
                    this.dayLowPrice = Math.Min(this.dayLowPrice, this.array[i].lowprice);

                    if (i >= 4 && this.array[i].avg5 == 0)
                    {
                        int sum = 0;
                        for (int j = i - 4; j <= i; j++)
                        {
                            sum += this.array[j].endprice;
                        }
                        this.array[i].avg5 = sum / 5;
                    }

                    if (i >= 19 && this.array[i].avg20 == 0)
                    {
                        int sum = 0;
                        for (int j = i - 19; j <= i; j++)
                        {
                            sum += this.array[j].endprice;
                        }
                        this.array[i].avg20 = sum / 20;
                    }    

                    if (i >= 119 && this.array[i].avg120 == 0)
                    {
                        int sum = 0;
                        for (int j = i-119; j <= i; j++)
                        {
                            sum += this.array[j].endprice;
                        }
                        this.array[i].avg120 = sum / 120;
                    }    
                    this.endDate = this.array[i].date;
                }
                else
                {
                    this.lastIdx = i - 1;
                    break; 
                }
            }   
        }

        public Boolean IsUpperThanDayStartPrice(int current)
        {
            if (array[dayStartIdx] != null && array[dayStartIdx].startprice != 0)
            {
                if (array[current] != null && array[current].endprice != 0) // current price ???
                {
                    return array[dayStartIdx].startprice < array[current].endprice;
                }
            }
            return false;
        }

        public Boolean IsAvg5Rising(int olderOffset, int oldOffset, int current)
        {
            if (current <= array.Length - 1 && current - olderOffset >= 0)
            {
                if (array[current - olderOffset] != null && array[current - oldOffset] != null)
                {
                    if (array[current - olderOffset].avg5 != 0 && array[current - oldOffset].avg5 != 0)
                    {
                        return array[current - olderOffset].avg5 < array[current - oldOffset].avg5;
                    }
                }
                else if (array[current - olderOffset] == null || array[current - olderOffset].avg5 == 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg5 value is not set. index = " + (current - olderOffset));
                }
                else if (array[current - oldOffset] != null || array[current - oldOffset].avg5 != 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg5 value is not set. index = " + (current - oldOffset));
                }
            } else
            {
                Console.WriteLine("[" + code + "][" + endDate + "] Index out of bound. older index = " + (current - olderOffset) + ", current index = " + current);
            }
            return false;
        }
        private Boolean IsAvg5Falling(int olderOffset, int oldOffset, int current)
        {
            if (current <= array.Length - 1 && current - olderOffset >= 0)
            {
                if (array[current - olderOffset] != null && array[current - oldOffset] != null)
                {
                    if (array[current - olderOffset].avg5 != 0 && array[current - oldOffset].avg5 != 0)
                    {
                        return array[current - olderOffset].avg5 > array[current - oldOffset].avg5;
                    }
                }
                else if (array[current - olderOffset] == null || array[current - olderOffset].avg5 == 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg5 value is not set. index = " + (current - olderOffset));
                }
                else if (array[current - oldOffset] != null || array[current - oldOffset].avg5 != 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg5 value is not set. index = " + (current - oldOffset));
                }
            } else
            {
                Console.WriteLine("[" + code + "][" + endDate + "] Index out of bound. older index = " + (current - olderOffset) + ", current index = " + current);
            }
            return false;
        }

        public Boolean IsAvg20Rising(int olderOffset, int oldOffset, int current)
        {
            if (current <= array.Length - 1 && current - olderOffset >= 0)
            {
                if (array[current - olderOffset] != null && array[current - oldOffset] != null)
                {
                    if (array[current - olderOffset].avg20 != 0 && array[current - oldOffset].avg20 != 0)
                    {
                        return array[current - olderOffset].avg20 < array[current - oldOffset].avg20;
                    }
                }
                else if (array[current - olderOffset] == null || array[current - olderOffset].avg20 == 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg20 value is not set. index = " + (current - olderOffset));
                }
                else if (array[current - oldOffset] != null || array[current - oldOffset].avg20 != 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg20 value is not set. index = " + (current - oldOffset));
                }
            } else
            {
                Console.WriteLine("[" + code + "][" + endDate + "] Index out of bound. older index = " + (current - olderOffset) + ", current index = " + current);
            }
            return false;
        }

        public Boolean IsAvg120Rising(int olderOffset, int oldOffset, int current)
        {
            if (current <= array.Length - 1 && current - olderOffset >= 0)
            {
                if (array[current - olderOffset] != null && array[current - oldOffset] != null)
                {
                    if (array[current - olderOffset].avg120 != 0 && array[current - oldOffset].avg120 != 0)
                    {
                        return array[current - olderOffset].avg120 < array[current - oldOffset].avg120;
                    }
                }
                else if (array[current - olderOffset] == null || array[current - olderOffset].avg120 == 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg120 value is not set. index = " + (current - olderOffset));
                }
                else if (array[current - oldOffset] != null || array[current - oldOffset].avg120 != 0)
                {
                    //Console.WriteLine("[" + code + "][" + endDate + "] avg120 value is not set. index = " + (current - oldOffset));
                }
            } else
            {
                Console.WriteLine("[" + code + "][" + endDate + "] Index out of bound. older index = " + (current - olderOffset) + ", current index = " + current);
            }
            return false;
        }

        public Boolean IsAvg5ChangeToUp(int current)
        {
            return IsAvg5Falling(-2, -1, current) && IsAvg5Rising(-1, -0, current);
        }

        public Boolean IsVolumeRising(int current)
        {
            if (array[current - 1] != null && array[current - 1].volume != 0)
            {
                if (array[current] != null && array[current].volume != 0)
                {
                    return array[current - 1].volume < array[current].volume;
                }
            }
            return false;
        }

    }
}
