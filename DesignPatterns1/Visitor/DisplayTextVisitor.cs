﻿using System;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Controller;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Visitor
{
	public class DisplayTextVisitor : IVisitor
	{
		private IOutputHandler _outputHandler;

		public DisplayTextVisitor(IOutputHandler outputHandler)
		{
			this._outputHandler = outputHandler;
		}

		public void Visit(Component visitee)
		{
			throw new NotImplementedException();
		}

		public void Visit(InputNode visitee)
		{
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
			_outputHandler.SendNodeValues(
				visitee.Name,
				"XorNode",
				visitee.Inputs,
				visitee.Result,
				(visitee.EndTime - visitee.StartTime)
			);
		}
	}
}