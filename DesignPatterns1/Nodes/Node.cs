using System.Collections.Generic;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
   public class Node : INode
    {
        public Node()
        {
        }

		public void AddOutputNode(IOutputNode outputNode)
		{
			throw new System.NotImplementedException();
		}

		public void ClearValues()
		{
			throw new System.NotImplementedException();
		}

		public bool DidWork()
		{
			throw new System.NotImplementedException();
		}

		public void DoAction() {

        }

		public string GetLiteralName()
		{
			throw new System.NotImplementedException();
		}

		public List<INode> GetOutputNodes()
		{
			throw new System.NotImplementedException();
		}

		public void AddValue(bool hasValue)
		{
			throw new System.NotImplementedException();
		}

		public void HeightenInputAmount()
		{
			throw new System.NotImplementedException();
		}

		public bool IsInput()
		{
			throw new System.NotImplementedException();
		}

		public bool IsOutput()
		{
			throw new System.NotImplementedException();
		}

		public void SetInputAmount(int inputAmount)
		{
			throw new System.NotImplementedException();
		}

		public void SetLiteralName(string name)
		{
			throw new System.NotImplementedException();
		}

		public void SetOutputHandler(IOutputHandler handler)
		{
			throw new System.NotImplementedException();
		}
	}
}
