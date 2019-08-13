﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ThreeData
    {
        public Candle[] array;
        public int dayStartIdx;
        public int dayHighPrice;
        public int dayLowPrice;

        public void AddThreeArray(Candle[] array)
        {
            if (array == null || array.Length == 0)
            {
                this.array = array;
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

                    Console.WriteLine(this.array[i].time); // for check
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
                }
            }   
        }
    }
}