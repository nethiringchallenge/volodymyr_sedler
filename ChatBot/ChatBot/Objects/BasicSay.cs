using System;

using ChatBot.Interfaces;

namespace ChatBot.Objects
{
    public class BasicSay : ISay
    {
        public string StarterText = "> ";
        public string BotHeyText = "[bot] ";
        public string BadCalcSayText = "У тебя в голове мозги или кю?!";
        public string GoodCalcSayText = "Я тебя полюбил — я тебя научу: ";

        public void Say(string aText = "") {
            Console.WriteLine(string.Concat(StarterText, BotHeyText, aText));
        }

        public void BadCalcSay() {
            Say(BadCalcSayText);
        }

        public void GoodCalcSay(int aResult) {
            Say(string.Concat(GoodCalcSayText, aResult.ToString()));
        }
    }
}
