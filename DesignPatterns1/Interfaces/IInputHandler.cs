﻿using System;
using System.Collections.Generic;

namespace DesignPatterns1.Interfaces
{
    public interface IInputHandler
    {
        void Start();
        Boolean SetCircuit(String s);
        void ShowCircuit();
        void ChangeInputNode(string nodeName, bool input);
    }
}
