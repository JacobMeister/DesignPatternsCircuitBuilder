using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Visitor
{
    public class DisplayOutputVisitor : IVisitor
	{
		private IOutputHandler _outputHandler;
        private long _cumulativeDelay;

		public DisplayOutputVisitor(IOutputHandler outputHandler)
		{
			this._outputHandler = outputHandler;
            _cumulativeDelay = 0;
		}

		public void Visit(Component visitee)
		{
            //throw new NotImplementedException();
		}

		public void Visit(InputNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"Input",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(OutputNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.AddOutput(visitee.Name, visitee.Result);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"Output",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(AndNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"AndNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(OrNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"OrNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(NotAndNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"NotAndNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(NotNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"NotNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(NotOrNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"NotOrNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

		public void Visit(XorNode visitee)
		{
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
				visitee.Name,
				"XorNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}

        public void Visit(Circuit visitee)
        {
            _outputHandler.Write("Circuit completed in: "
                + _cumulativeDelay
                + " nanoseconds with a total of: "
				+ (visitee.EndTime - visitee.StartTime)
				+ " nanoseconds to console log!");
        }

        public void Visit(Node visitee)
        {
            _cumulativeDelay += (visitee.EndTime - visitee.StartTime);

            _outputHandler.SendNodeValues(
                visitee.Name,
                "Node",
                visitee.Inputs,
                visitee.Result,
                (visitee.EndTime - visitee.StartTime)
            );
        }
    }
}
