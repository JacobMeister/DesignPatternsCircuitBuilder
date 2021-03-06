﻿using System.Collections.Generic;

namespace DesignPatterns1.Interfaces
{
    public interface INode
    {
        void DoAction();
        void AddValue(bool hasValue);
        void AddOutputNode(INode INode);
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
		string GetName();
    }
}
