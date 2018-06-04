using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Circuit;

namespace DesignPatterns1.Interfaces
{
    public interface IInputHandler
    {
        void Start();
        void InitiateCircuit(String circuitDataLines);
        void ShowCircuit();
        void ChangeInputNode(string nodeName, bool input);
        Circuit GetCircuit();
    }
}
