using System.Linq;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Visitor
{
    public class ValidationVisitor : IVisitor
    {
        private IOutputHandler _outputHandler;
        private bool _isLoopingInfinitly;

        public ValidationVisitor(IOutputHandler outputHandler)
        {
            this._outputHandler = outputHandler;
        }

        //public void Visit(Component visitee)
        //{
        //    throw new NotImplementedException();
        //}

        public void Visit(Node visitee)
        {
            if (visitee.OutputEdges.Count == 0)
            {
                _outputHandler.Write("WARNING: Node " + visitee.Name + " is not connected to next nodes!");
            }
        }

        public void Visit(Circuit visitee)
        {
            int maxNodeCount = 0;
            maxNodeCount += visitee.EntryNodes.Count;
            maxNodeCount += visitee.GridNodes.Count;
            maxNodeCount += visitee.ResultNodes.Count;

            for (int i = 0; i < visitee.EntryNodes.Count; i++)
                {
                    IsInfiniteLoop(visitee.EntryNodes[i], 0, maxNodeCount);
                    if (_isLoopingInfinitly) {
                        _outputHandler.Write("ERROR: Infinite Loop detected");
                        return;
                    }
                }
        }

        public void Visit(Component visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(AndNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(NotAndNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(NotNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(OrNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(NotOrNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(XorNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(InputNode visitee)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(OutputNode visitee)
        {
            throw new System.NotImplementedException();
        }

        private void IsInfiniteLoop(Component node, int level, int maxNodeCount)
        {
            foreach (Edge child in node.OutputEdges)
            {
                if (level > maxNodeCount) {
                _isLoopingInfinitly = true;
                break;
                }
                IsInfiniteLoop(child.GetEndComponent(), level + 1, maxNodeCount);
            }
        }
    }
}
