using System.Linq;

namespace DesignPatterns1.Components.Nodes
{
    public class InputNode : Node
    {
		public InputNode() : base() { }

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
            return new InputNode();
        }
    }
}
