using DesignPatterns1.Visitor;

namespace DesignPatterns1.Interfaces
{
	public interface IInputNode : INode
    {
        void Accept(DisplayTextVisitor visitor);
    }
}
