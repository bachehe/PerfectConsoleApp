using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateLibrary.Interfaces;

namespace UltimateLibrary.Helpers;
public class InputReader : IInputReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}

