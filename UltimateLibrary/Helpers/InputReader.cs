﻿using UltimateLibrary.Interfaces;

namespace UltimateLibrary.Helpers;
public class InputReader : IInputReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}

