using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
	public class AndNode : INode
	{
		private List<INode> outputNodes = new List<INode>();
		private List<bool> values = new List<bool>();
		private int inputAmount;
		private String literalName;
		private String name = "AND";
		private bool isInput = false;
		private bool isOutput = false;
		private IOutputHandler handler;

		public AndNode()
		{
			outputNodes = new List<INode>();
			inputAmount = 0;
		}

		public void AddOutputNode(INode outputNode)
		{
			outputNodes.Add(outputNode);
		}

		public void AddValue(bool hasValue)
		{
			values.Add(hasValue);
			if (values.Count == inputAmount)
			{
				DoAction();
			}
		}

		public void ClearValues()
		{
			this.values.Clear();
		}

		public bool DidWork()
		{
			if (values.Count == inputAmount || inputAmount < 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void DoAction()
		{
			long start_time = NanoTime();

			Boolean output = true;

			//AND, if all values are true, send true, otherwise send false.
			values.ForEach((bool obj) => {
				output &= obj;
			});

			outputNodes.ForEach((INode obj) => obj.AddValue(output));

			long end_time = NanoTime();

			if (handler != null)
			{
				handler.SendNodeValues(this.GetLiteralName(), name, values, output, (end_time - start_time));
			}
		}

		public string GetLiteralName()
		{
			return literalName;
		}

		public string GetName()
		{
			return name;
		}

		public List<INode> GetOutputNodes()
		{
			return outputNodes;
		}

		public void HeightenInputAmount()
		{
			inputAmount++;
		}

		public bool IsInput()
		{
			return isInput;
		}

		public bool IsOutput()
		{
			return isOutput;
		}

		public void SetInputAmount(int inputAmount)
		{
				if (inputAmount > 0)
				{
					this.inputAmount = inputAmount;
				}
		}

		public void SetLiteralName(string name)
		{
			this.literalName = name;
		}

		public void SetOutputHandler(IOutputHandler handler)
		{
				this.handler = handler;
		}

		public long NanoTime()
		{
			long nano = 10000L * Stopwatch.GetTimestamp();
			nano /= TimeSpan.TicksPerMillisecond;
			nano *= 100L;
			return nano;
		}
	}
}
