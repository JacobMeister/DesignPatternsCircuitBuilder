using System.Collections.Generic;

namespace DesignPatterns1.Interfaces
{
    public interface INode
    {
        void DoAction();
        void HasValue(bool hasValue);
        void AddOutputNode(IOutputNode outputNode);
        void SetInputAmount(int inputAmount);
        void HeightenInputAmount();
        List<INode> GetOutputNodes();
        bool IsInput();
        bool IsOutput();
        string GetLiteralName();
        void SetLiteralName(string name);
        void ClearValues();
        bool DidWork();
        void SetOutputHandler(IOutputHandler handler);
    }
}
