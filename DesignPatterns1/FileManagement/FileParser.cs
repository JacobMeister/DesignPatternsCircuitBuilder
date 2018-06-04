using System;
using System.Collections.Generic;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Repository;

namespace DesignPatterns1.FileManagement
{
    public class FileParser
    {
        IOutputHandler _output;

        public FileParser(IOutputHandler output)
        {
            this._output = output;
        }

        public void ParseCircuit(string url)
        {
            //CircuitDataRepository.Instance.ClearData();
            FileReader fr = new FileReader(_output);
            Boolean readingEdges = false;
            foreach (string s in fr.GetLines(url))
            {
                if(s.Equals("# Description of all the edges"))
                {
                    readingEdges = true;
                }
                if (!s.StartsWith("#") && !string.IsNullOrEmpty(s))
                {

                    if (s.Contains(":") && s.EndsWith(";"))
                    {
                        String[] cleanedStrings = CleanUpStrings(s);
                        if (readingEdges == true)
                        {
                            AddEdge(cleanedStrings);
                        }
                        else
                        {
                            AddNode(cleanedStrings);
                        }
                    }
                }
            }
        }

        public void AddEdge(String[] cleanedStrings)
        {
            List<String> nodes = new List<string>();
            String[] outputNodes = cleanedStrings[1].Split(',');
            foreach (String nodeName in outputNodes)
            {
                nodes.Add(nodeName);
            }
            CircuitDataRepository.Instance.AddEdgeData(cleanedStrings[0], nodes);
            
        }

        public void AddNode(String[] cleanedStrings)
        {
            Boolean running = true;
            while (running)
            {
                if (CircuitDataRepository.Instance.IsNameValid(cleanedStrings[0]))
                {
                    break;
                }
                cleanedStrings[0] = cleanedStrings[0] + "#";
            }
            if(cleanedStrings[1].Equals("INPUT_LOW"))
            {
                CircuitDataRepository.Instance.AddInputNodeData(cleanedStrings[0], false);
            }
            else if (cleanedStrings[1].Equals("INPUT_HIGH"))
            {
                CircuitDataRepository.Instance.AddInputNodeData(cleanedStrings[0], true);
            }
            else if (cleanedStrings[1].Equals("PROBE"))
            {
                CircuitDataRepository.Instance.AddOutputNodeData(cleanedStrings[0]);
            }
            else
            {
                CircuitDataRepository.Instance.AddGridNodeData(cleanedStrings[0], cleanedStrings[1]);
            }
        }

        public String[] CleanUpStrings(String s)
        {
            string word = s.Replace(";", "");
            word = word.Replace("\t", "");
            word = word.Replace("\\s", "");

            String[] parts = word.Split(':');

            parts[0] = parts[0].Trim();
            parts[1] = parts[1].Trim();
            return parts;
        }
        
    }
}
