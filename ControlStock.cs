using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxKHOpenAPILib;

namespace WindowsFormsApp1
{
    class ControlStock
    {
        public AxKHOpenAPI axKHOpenAPI1;
        public Control control;

        public void InquireDayInfo(string code, string endDate)
        {
            axKHOpenAPI1.SetInputValue("종목코드", code);
            axKHOpenAPI1.SetInputValue("기준일자", endDate);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet;
            if (true) // TODO do i neeed 연속조회
            {
                // 신규조회
                nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            }
            else
            {
                // 연속조회
                nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 2, "1002");
            }

            if (nRet == 0)
            {
                control.Print("주식정보요청 성공");
            } else
            {
                control.Print("주식정보요청 실패");
            }
        }

    }
}
