using System;
using System.Collections.Generic;
using DesignPatterns1.FileManagement;

namespace DesignPatterns1.Interfaces
{
    public interface IOutputHandler
    {
        void DoOutput(string name, bool value);
	    void SendNodeValues(string name, string type, List<bool> inputs, bool output, long time);
	    void Write(string s);
        void EnableButtons();
        void OpenMultipleCircuits(FileParser parser);
        void SetCheckList();
        void AddOutput(String nodeName, Boolean value);
    }
}