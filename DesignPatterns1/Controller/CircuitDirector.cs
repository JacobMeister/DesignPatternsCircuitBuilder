using System;
using System.Collections.Generic;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Visitor;
using DesignPatterns1.FileManagement;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Builder;
using DesignPatterns1.Repository;

namespace DesignPatterns1.Controller
{
    public class CircuitDirector : IInputHandler
    {
        private FileParser _parser;
        private IOutputHandler _outputHandler;
        private Circuit _circuit;

        public CircuitDirector()
        {
            
        }
        
        public void SetOutputHandler(IOutputHandler output)
        {
            _outputHandler = output;
            _parser = new FileParser(output);
        }

        public void ChangeInputNodes(List<string> temp)
        {
            
        }

        public bool SetCircuit(string s)
        {

            
            if (s.ToLower().EndsWith(".txt"))
            {
                _parser.ParseCircuit(s);
                CircuitBuilder circuitBuilder = new CircuitBuilder(CircuitDataRepository.Instance);
                Construct(circuitBuilder);
                _circuit = circuitBuilder.GetResult();
                //dowarnings
                return true;
            }
            else
            {
                _outputHandler.Write("WARNING: File must have .txt extension!");
                return false;
            }

            
        }

        private void Construct(CircuitBuilder builder) {
            builder.BuildInputNodes();
            builder.BuildOutputNodes();
            builder.BuildGridNodes();
            builder.BuildEdges();
        }


        public void ShowCircuit()
        {
			_circuit.EntryNodes.ForEach((node) => {
				node.Accept(new DisplayEdgesVisitor(_outputHandler));
			});
			_circuit.GridNodes.ForEach((node) => {
				node.Accept(new DisplayEdgesVisitor(_outputHandler));
			});
			_circuit.ResultNodes.ForEach((node) => {
				node.Accept(new DisplayEdgesVisitor(_outputHandler));
			});
        }

        public void Start()
        {
            _circuit.Run(new DisplayOutputVisitor(_outputHandler));
        }
        
    }
}

