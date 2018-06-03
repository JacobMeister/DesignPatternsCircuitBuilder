using System;
using System.Collections.Generic;

namespace DesignPatterns1.Repository
{
    public class CircuitDataRepository
    {
        public CircuitDataRepository()
        {
        }

		public Dictionary<string, List<string>> GetEdgesData()
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, string> GetGridNodesData()
        {
            throw new NotImplementedException();
        }

		public Dictionary<string, bool> GetInputNodesData()
        {
            throw new NotImplementedException();
        }

        internal List<string> GetOutputNodesData()
        {
            throw new NotImplementedException();
        }
   	}
}
