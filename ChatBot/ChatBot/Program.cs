using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ChatBot.Objects;

namespace ChatBot
{
    public class Program
    {
        private static string _inputChar = "> ";
        private static string _botInitStartText = "talk_to_me";
        private static string _botHelloText = "Привет. Как дела на плюке?";
        private static string _fileName;
        private static long _maxFileSixe = 1000000000;
        private static List<string> _answerList;
        private static List<string> _commandList = new List<string>() { "strategy:", "calculate:" };

        public enum strategy { rand, upseq, downseq };
        public static strategy BotStrategy = strategy.rand;
        public static BasicSay BotSay = new BasicSay();

        public static bool InitBot(string aInitStr) {
            if (!aInitStr.Contains(_botInitStartText)) {
                return false;
            }
            // Getting strategy
            int rPos = aInitStr.IndexOf("-r");
            string strategyStr = aInitStr.Substring(rPos + 3, aInitStr.IndexOf(" ", rPos) - rPos + 3);
            //Console.WriteLine(strategyStr);
            BotStrategy = (strategy)Enum.Parse(typeof(strategy), strategyStr);
            // Getting filename
            int fPos = aInitStr.IndexOf("-f");
            _fileName = aInitStr.Substring(fPos + 3);
            Console.WriteLine(_fileName);
            if (!File.Exists(_fileName)) {
                return false;
            }
            return File.Exists(_fileName) && (new FileInfo(_fileName)).Length <= _maxFileSixe;
        }

        public static void ShowInputChar() {
            Console.Write(_inputChar);
        }

        public static void BotWait() {
            Console.ReadKey();
        }

        public static void LoadAnswers() {
            _answerList = File.ReadAllLines(_fileName).ToList();
        }

        static void Main(string[] args) {
            try {
                ShowInputChar();
                if (!InitBot(Console.ReadLine())) {
                    BotSay.Say("Cant init");
                    BotWait();
                }
                LoadAnswers();
                BotSay.Say(_botHelloText);
                /*while (Console.ReadLine()) {

                }*/
            } catch (Exception e) {
                BotSay.Say(e.Message);
                BotSay.Say(e.StackTrace);
            }
        }
    }
}
