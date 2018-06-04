using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns1.Repository
{
    public class CircuitDataRepository
    {
        private static readonly CircuitDataRepository _instance = new CircuitDataRepository();

        private Dictionary<string, string> _gridNodesData;
        private Dictionary<string, bool> _inputNodesData;
        private List<string> _outputNodesData;
        private Dictionary<string, List<string>> _edgesData;

        static CircuitDataRepository()
        {
        }

        private CircuitDataRepository()
        {   
            _gridNodesData = new Dictionary<string, string>();
            _inputNodesData = new Dictionary<string, bool>();
            _outputNodesData = new List<string>();
            _edgesData = new Dictionary<string, List<string>>();
        }

        public static CircuitDataRepository Instance
        {
            get
            {
                return _instance;
            }
        }

		public Dictionary<string, List<string>> GetEdgesData()
		{
			return _edgesData;
		}

		public Dictionary<string, string> GetGridNodesData()
        {
            return _gridNodesData;
        }

		public Dictionary<string, bool> GetInputNodesData()
        {
            return _inputNodesData;
        }

        public List<string> GetOutputNodesData()
        {
            return _outputNodesData;
        }

        public void AddEdgeData(Dictionary<string, List<string>> edgesData)
		{
            _edgesData = _edgesData.Union(edgesData).ToDictionary(k => k.Key, v => v.Value);
		}

		public void AddGridNodeData(Dictionary<string, string> gridNodesData)
        {
           _gridNodesData = _gridNodesData.Union(gridNodesData).ToDictionary(k => k.Key, v => v.Value);
        }

		public void AddInputNodeData(Dictionary<string, bool> inputNodesData)
        {
            _inputNodesData = _inputNodesData.Union(inputNodesData).ToDictionary(k => k.Key, v => v.Value);
        }

        public void AddOutputNodeData(List<string> outputNodesData)
        {
            _outputNodesData.AddRange(outputNodesData);
        }

        public bool IsMultipleCircuit() {
            return _inputNodesData.Count != 0;
        }

		public bool IsNameValid(string name)
		{
            if (_inputNodesData.ContainsKey(name) || _gridNodesData.ContainsKey(name) || _outputNodesData.Contains(name)) 
            {
                return false;
            }
            return true;   
		}

        public void ClearData() {
            _gridNodesData.Clear();
            _inputNodesData.Clear();
            _outputNodesData.Clear();
            _edgesData.Clear();
        }

        public void DeleteOutputNode(String nodeName)
        {
            _outputNodesData.Remove(nodeName);
        }
   	}
}
