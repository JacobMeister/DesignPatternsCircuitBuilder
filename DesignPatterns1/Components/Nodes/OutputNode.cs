﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Components.Nodes
{
	public class OutputNode : Node
	{
		public OutputNode() : base() { }

		protected override void CalculateResult()
		{
			Result = Inputs.First();
		}

        public override void Accept(Visitor.IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override Node Clone()
        {
            return new OutputNode();
        }
    }
}
