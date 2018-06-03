﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
	public class OrNode : Node
	{
		public OrNode() : base() { }

		protected override void CalculateResult()
		{
			Inputs.ForEach((bool input) => { 
				Result |= input;
			});
		}
	}
}
