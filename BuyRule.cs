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

            public static HashSet<string> GetMassRule()
            {
                HashSet<string> keySet = new HashSet<string>();
                foreach (string c1 in BuyRule.Pattern.isPlusArray)
                {
                    foreach (string c2 in BuyRule.Pattern.isAvg5UpperThanAvg20Array)
                    {
                        foreach (string c3 in BuyRule.Pattern.isAvg20UpperThanAvg120Array)
                        {
                            foreach (string c4 in BuyRule.Pattern.isAvgGoldenArray)
                            {
                                foreach (string c5 in BuyRule.Pattern.isUpperThanDayStartPriceArray)
                                {
                                    foreach (string c6 in BuyRule.Pattern.isAvg5ChangeToUpArray)
                                    {
                                        foreach (string c7 in BuyRule.Pattern.isAvg5RisingArray)
                                        {
                                            for (int i = 0; i < BuyRule.Pattern.indexRange.Length / 2; i++)
                                            {
                                                foreach (string c8 in BuyRule.Pattern.isAvg20RisingArray)
                                                {
                                                    for (int j = 0; j < BuyRule.Pattern.indexRange.Length / 2; j++)
                                                    {
                                                        foreach (string c9 in BuyRule.Pattern.isAvg120RisingArray)
                                                        {
                                                            for (int k = 0; k < BuyRule.Pattern.indexRange.Length / 2; k++)
                                                            {
                                                                StringBuilder rule = new StringBuilder();
                                                                if (!String.IsNullOrEmpty(c1))
                                                                {
                                                                    rule.Append(c1).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c2))
                                                                {
                                                                    rule.Append(c2).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c3))
                                                                {
                                                                    rule.Append(c3).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c4))
                                                                {
                                                                    rule.Append(c4).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c5))
                                                                {
                                                                    rule.Append(c5).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c6))
                                                                {
                                                                    rule.Append(c6).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c7))
                                                                {
                                                                    rule.Append(c7);
                                                                    rule.Append(" ").Append(BuyRule.Pattern.indexRange[i, 0]);
                                                                    rule.Append(",").Append(BuyRule.Pattern.indexRange[i, 1]).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c8))
                                                                {
                                                                    rule.Append(c8);
                                                                    rule.Append(" ").Append(BuyRule.Pattern.indexRange[j, 0]);
                                                                    rule.Append(",").Append(BuyRule.Pattern.indexRange[j, 1]).Append("&");
                                                                }
                                                                if (!String.IsNullOrEmpty(c9))
                                                                {
                                                                    rule.Append(c9);
                                                                    rule.Append(" ").Append(BuyRule.Pattern.indexRange[k, 0]);
                                                                    rule.Append(",").Append(BuyRule.Pattern.indexRange[k, 1]).Append("&");
                                                                }
                                                                string buyRule = rule.ToString().TrimEnd('&');

                                                                if (!keySet.Contains(buyRule))
                                                                {
                                                                    keySet.Add(buyRule);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return keySet;
            }
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
