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
        private IOutputHandler _outputHandler;
        private Circuit _circuit;
        
        public CircuitDirector()
        {
            
        }
        
        public void SetOutputHandler(IOutputHandler output)
        {
            _outputHandler = output;
        }

        public void ChangeInputNode(string nodeName, bool input)
        {
            _circuit.EntryNodes.ForEach(node =>
            {
                if (node.Name.Equals(nodeName))
                {
                    node.Inputs[0] = input;
                }
            });
        }

        public Circuit GetCircuit()
        {
            return _circuit;
        }

        public void InitiateCircuit(string circuitDataLines)
        {
            InitiateParser(circuitDataLines);
            BuildCircuit();
            _outputHandler.EnableButtons();  
        }

        private void InitiateParser(string circuitDataLines) {
            FileParser parser = new FileParser(_outputHandler);
            parser.ParseCircuit(circuitDataLines);
                if (CircuitDataRepository.Instance.IsMultipleCircuit()) {
                    _outputHandler.OpenMultipleCircuits(parser);
                }
            parser.PushLists();
            _outputHandler.SetCheckList();
        }

        private void ValidateCircuit()
        {
            _circuit.Accept(new ValidationVisitor(_outputHandler));

            _circuit.EntryNodes.ForEach((node) => {
                node.Accept(new ValidationVisitor(_outputHandler));
            });
            _circuit.GridNodes.ForEach((node) => {
                node.Accept(new ValidationVisitor(_outputHandler));
            });
        }

        private void BuildCircuit() {
            CircuitBuilder circuitBuilder = new CircuitBuilder();
            Construct(circuitBuilder);
            _circuit = circuitBuilder.GetResult();
            ValidateCircuit();
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
            CleanCircuit();
            _circuit.Run(new DisplayOutputVisitor(_outputHandler));
        }

        private void CleanCircuit()
        {
            _circuit.EntryNodes.ForEach((node) => {
                node.Reset();
            });
            _circuit.GridNodes.ForEach((node) => {
                node.Reset();
            });
            _circuit.ResultNodes.ForEach((node) => {
                node.Reset();
            });

            _circuit.Reset();
        }
    }
}

