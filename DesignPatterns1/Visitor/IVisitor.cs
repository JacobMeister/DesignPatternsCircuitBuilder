using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Visitor
{
	public interface IVisitor
    {
		void Visit(INode visitee);
    }
}
