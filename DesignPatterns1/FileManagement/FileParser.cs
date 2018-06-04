using System;
using System.Collections.Generic;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Repository;

namespace DesignPatterns1.FileManagement
{
    public class FileParser
    {
        private IOutputHandler _output;
        private Dictionary<string, bool> _inputNodes;
        private List<string> _outputNodes;
        private Dictionary<string, string> _gridNodes;
        private Dictionary<string, List<string>> _edgesData;

        public FileParser(IOutputHandler output)
        {
            _output = output;
            _gridNodes = new Dictionary<string, string>();
            _inputNodes = new Dictionary<string, bool>();
            _outputNodes = new List<string>();
            _edgesData = new Dictionary<string, List<string>>();
        }

        public void ParseCircuit(string url)
        {

            FileReader fr = new FileReader(_output);
            Boolean readingEdges = false;
            List<String> lines = fr.GetLines(url);
            if (lines != null)
            {
                foreach (string s in lines)
                {
                    if (s.Equals("# Description of all the edges"))
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



        }

        private void AddEdge(String[] cleanedStrings)
        {
            if (!CircuitDataRepository.Instance.IsNameValid(cleanedStrings[0]))
            {
                cleanedStrings[0] = cleanedStrings[0] + "#";
            }
            List<String> nodes = new List<string>();
            String[] outputNodes = cleanedStrings[1].Split(',');
            foreach (String nodeName in outputNodes)
            {
                string name = nodeName;
                if (!CircuitDataRepository.Instance.IsNameValid(name))
                {
                    name = name + "#";
                }
                nodes.Add(name);
            }
            _edgesData.Add(cleanedStrings[0], nodes);

        }

        private void AddNode(String[] cleanedStrings)
        {

            if (!CircuitDataRepository.Instance.IsNameValid(cleanedStrings[0]))
            {
                cleanedStrings[0] = cleanedStrings[0] + "#";
            }

            if (cleanedStrings[1].Equals("INPUT_LOW"))
            {
                _inputNodes.Add(cleanedStrings[0], false);
            }
            else if (cleanedStrings[1].Equals("INPUT_HIGH"))
            {
                _inputNodes.Add(cleanedStrings[0], true);
            }
            else if (cleanedStrings[1].Equals("PROBE"))
            {
                _outputNodes.Add(cleanedStrings[0]);
            }
            else
            {
                _gridNodes.Add(cleanedStrings[0], cleanedStrings[1]);
            }
        }

        public void PushLists()
        {
            CircuitDataRepository.Instance.AddEdgeData(_edgesData);
            CircuitDataRepository.Instance.AddGridNodeData(_gridNodes);
            CircuitDataRepository.Instance.AddInputNodeData(_inputNodes);
            CircuitDataRepository.Instance.AddOutputNodeData(_outputNodes);
        }

        private String[] CleanUpStrings(String s)
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
