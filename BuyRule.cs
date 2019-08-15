using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BuyRule
    {
        public static class Pattern
        {
            public static string[] isPlusArray = { "", "IsPlus" };
            public static string[] isAvg5UpperThanAvg20Array = { "", "IsAvg5UpperThanAvg20" };
            public static string[] isAvg20UpperThanAvg120Array = { "", "IsAvg20UpperThanAvg120" };
            public static string[] isAvgGoldenArray = { "", "IsAvgGolden" };
            public static string[] isUpperThanDayStartPriceArray = { "", "IsUpperThanDayStartPrice" };
            public static string[] isAvg5ChangeToUpArray = { "", "IsAvg5ChangeToUp" };
            public static string[] isVolumeRisingArray = { "", "IsVolumeRising" };
            public static string[] isAvg5RisingArray = { "", "IsAvg5Rising" };
            public static string[] isAvg20RisingArray = { "", "IsAvg20Rising" };
            public static string[] isAvg120RisingArray = { "", "IsAvg120Rising" };
            public static int[,] indexRange = new int[,] { { -1, 0 }, { -2, 0 } };
        }


        public static Boolean Judge(ThreeData data, int chkIndex, string ruleString)
        {
            Boolean result = false;

            char[] charsToTrim = { '\r', '\n' };
            string trimmed = ruleString.Trim(charsToTrim);
            string[] rules = ruleString.Split('.');
            foreach (string rule in rules)
            {
                string[] conditions = rule.Split('&');
                foreach (string condition in conditions)
                {
                    if (data.array[chkIndex] != null && !String.IsNullOrWhiteSpace(condition))
                    {
                        // single candle check
                        if ("IsPlus".Equals(condition))
                        {
                            result = data.array[chkIndex].IsPlus();
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsAvg5UpperThanAvg20".Equals(condition))
                        {
                            result = data.array[chkIndex].IsAvg5UpperThanAvg20();
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsAvg20UpperThanAvg120".Equals(condition))
                        {
                            result = data.array[chkIndex].IsAvg20UpperThanAvg120();
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsAvgGolden".Equals(condition))
                        {
                            result = data.array[chkIndex].IsAvgGolden();
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsIncludeTime".StartsWith(condition))
                        {
                            string[] ps = condition.Replace("IsIncludeTime", "").TrimStart().Split(',');
                            result = data.array[chkIndex].IsIncludeTime(Int32.Parse(ps[0]), Int32.Parse(ps[1]));
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsExcludeTime".StartsWith(condition))
                        {
                            string[] ps = condition.Replace("IsExcludeTime", "").TrimStart().Split(',');
                            result = data.array[chkIndex].IsIncludeTime(Int32.Parse(ps[0]), Int32.Parse(ps[1]));
                            if (result == false)
                            {
                                return false;
                            }
                        }

                        // multiple candle check
                        else if ("IsUpperThanDayStartPrice".Equals(condition))
                        {
                            result = data.IsUpperThanDayStartPrice(chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsAvg5ChangeToUp".Equals(condition))
                        {
                            result = data.IsAvg5ChangeToUp(chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if ("IsVolumeRising".Equals(condition))
                        {
                            result = data.IsVolumeRising(chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if (condition.StartsWith("IsAvg5Rising"))
                        {
                            string[] ps = condition.Replace("IsAvg5Rising", "").TrimStart().Split(',');
                            result = data.IsAvg5Rising(Int32.Parse(ps[0]), Int32.Parse(ps[1]), chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if (condition.StartsWith("IsAvg20Rising"))
                        {
                            string[] ps = condition.Replace("IsAvg20Rising", "").TrimStart().Split(',');
                            result = data.IsAvg20Rising(Int32.Parse(ps[0]), Int32.Parse(ps[1]), chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                        else if (condition.StartsWith("IsAvg120Rising"))
                        {
                            string[] ps = condition.Replace("IsAvg120Rising", "").TrimStart().Split(',');
                            result = data.IsAvg120Rising(Int32.Parse(ps[0]), Int32.Parse(ps[1]), chkIndex);
                            if (result == false)
                            {
                                return false;
                            }
                        }
                    }
                }

                if (result == true)
                {
                    return true;
                }
            }

            return result;
        }
    }
}
