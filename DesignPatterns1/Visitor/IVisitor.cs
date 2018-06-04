using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Visitor
{
	public interface IVisitor
    {
        void Visit(Component visitee);

        void Visit(Circuit visitee);
        
        void Visit(Node visitee);

        void Visit(AndNode visitee);
        
        void Visit(NotAndNode visitee);

        void Visit(NotNode visitee);

        void Visit(OrNode visitee);

        void Visit(NotOrNode visitee);
        
        void Visit(XorNode visitee);

        void Visit(InputNode visitee);

        void Visit(OutputNode visitee);
    }
}
