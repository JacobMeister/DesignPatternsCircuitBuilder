using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Controller
{
    class CircuitParser
    {
        Dictionary<String, String> nodeList = new Dictionary<String, String>();
        Dictionary<String, List<String>> edgeList = new Dictionary<String, List<String>>();
        IOutputHandler output;

        public CircuitParser(IOutputHandler output){
            this.output = output;
        }

        public void ParseCircuit(string url)
        {
            FileReader fr = new FileReader(output);

            foreach (string s in fr.GetLines(url))
            {
                if (!s.StartsWith("#") && !string.IsNullOrEmpty(s))
                {

                    if (s.Contains(":") && s.EndsWith(";"))
                    {
                        string word = s.Replace(";", "");
                        word = word.Replace("\t", "");
                        word = word.Replace("\\s", "");
                        
                        String[] parts = word.Split(':');

                        String name = parts[0].Trim();
                        String type = parts[1].Trim();
                        if (type.Contains(","))
                        {
                            List<String> nodes = new List<string>();
                            String[] outputNodes = type.Split(',');
                            foreach(String nodeName in outputNodes)
                            {
                                nodes.Add(nodeName);
                            }
                            edgeList.Add(name, nodes);
                        }
                        else
                        {
                            nodeList.Add(name, type);
                        }
                    }
                }
            }
        }

        public Dictionary<String, String> GetNodes()
        {
            return nodeList;
        }

        public Dictionary<String, List<String>> GetEdges()
        {
            return edgeList;
        }
    }
}
