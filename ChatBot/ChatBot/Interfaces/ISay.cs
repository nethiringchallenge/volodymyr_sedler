using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Interfaces
{
    public interface ISay
    {
        /// <summary>
        /// Just say smth
        /// </summary>
        void Say(string aText = "");
    }
}
