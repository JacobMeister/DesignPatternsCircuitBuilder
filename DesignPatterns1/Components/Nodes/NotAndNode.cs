using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Components.Nodes
{
	public class NotAndNode : Node
	{
		public NotAndNode() : base() { }

		protected override void CalculateResult()
		{
            Result = true;
			Inputs.ForEach((bool input) => {
				if (input)
                {
                    Result = false;
                }
			});
		}

        public override void Accept(Visitor.IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override Node Clone()
        {
            return new NotAndNode();
        }
    }
}
