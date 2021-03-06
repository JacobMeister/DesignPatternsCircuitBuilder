﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Components.Nodes
{
	public class XorNode : Node
	{
		public XorNode() : base() { }

		protected override void CalculateResult()
		{
			Result = (Inputs[0] != Inputs[1]);
		}

		public override void Accept(Visitor.IVisitor visitor) 
		{
			visitor.Visit(this);
		}

        public override Node Clone()
        {
            return new XorNode();
        }
    }
}
