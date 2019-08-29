using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Item 
    {
        public string code { get; set; }
        public string name { get; set; }
        public string target { get; set; }
        public string status { get; set; }
        public Int32 dayStartDate { get; set; }
        public Int32 dayEndDate { get; set; }
        public Int32 minStartDate { get; set; }
        public Int32 minEndDate { get; set; }
        public Int32 dayAvgStartDate { get; set; }
        public Int32 dayAvgEndDate { get; set; }
        public Int32 minAvgStartDate { get; set; }
        public Int32 minAvgEndDate { get; set; }
        public Int32 updDate { get; set; }
        public string update { get; set; }
        public string type { get; set; }

    }
}
