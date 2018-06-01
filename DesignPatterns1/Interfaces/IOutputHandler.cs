using System.Collections.Generic;

namespace DesignPatterns1.Interfaces
{
    public interface IOutputHandler
    {
        void DoOutput(string name, bool value);
	    void SendNodeValues(string name, string type, List<bool> inputs, bool output, long time);
	    void Write(string s);
        
    }
}