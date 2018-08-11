using System;
using System.Text.RegularExpressions;

using ChatBot.Interfaces;

namespace ChatBot.Objects
{
    public class BasicCalculate : ICalculate
    {
        private string _caclCommand = "calculate:";

        private int GetPlus(string aExpr) {
            string pattern = @".+[1-9].+\+.+[1-9]+";
            string realExpr = aExpr.Substring(0, _caclCommand.Length);
            Match m = Regex.Match(realExpr, pattern);
            if (m.Success) {
                int aplusPos = realExpr.IndexOf("+");
                int exprLeft = int.Parse(realExpr.Substring(0, aplusPos));
                int exprRight = int.Parse(realExpr.Substring(aplusPos + 1, realExpr.Length - aplusPos));
                if (exprLeft <= 0 || exprRight <= 0) {
                    return -1;
                }
                return exprLeft + exprRight;
            } else {
                return -1;
            }
        }

        public void Calculate(string aExpr, ISay aSayer) {
            int result = 0;
            BasicSay sayer = aSayer as BasicSay;
            try {
                result = GetPlus(aExpr);
                if (result == -1) {
                    sayer.BadCalcSay();
                    return;
                }
                sayer.GoodCalcSay(result);
            } catch (Exception e) {
                sayer.BadCalcSay();
                sayer.Say(e.StackTrace);
            }
        }
    }
}
