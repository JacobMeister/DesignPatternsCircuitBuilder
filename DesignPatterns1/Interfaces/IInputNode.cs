namespace DesignPatterns1.Interfaces
{
    public interface IInputNode
    {
        void Accept(InputNodeVisitor visitor);
    }
}
