using System;
using System.Collections.Generic;

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

        public void AddEdgeData(string nodeName, List<string> nodeNamesToConnectTo)
		{
			_edgesData.Add(nodeName, nodeNamesToConnectTo);
		}

		public void AddGridNodeData(string nodeName, string typeOfNode)
        {
            _gridNodesData.Add(nodeName, typeOfNode);
        }

		public void AddInputNodeData(string nodeName, bool input)
        {
            _inputNodesData.Add(nodeName, input);
        }

        public void AddOutputNodeData(string nodeName)
        {
            _outputNodesData.Add(nodeName);
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
   	}
}
