using System;
using System.Collections.Generic;
using System.Diagnostics;
using DesignPatterns1.Interfaces;
namespace DesignPatterns1.Controller
{
    public class CircuitController : IInputHandler
    {
        private Dictionary<String, IInputNode> inputNodes = new Dictionary<string, IInputNode>();
        private Dictionary<String, INode> nodes = new Dictionary<string, INode>();
        private Dictionary<String, IOutputNode> outputNodes = new Dictionary<string, IOutputNode>();
        private IOutputHandler output;

        public CircuitController(IOutputHandler output)
        {
            this.output = output;
        }
        
        public void ChangeInputNodes(List<string> temp)
        {
            foreach (string s in temp)

            {
                var value = this.inputNodes[s];
                if (value.getName() == "INPUT_HIGH")
                {
                    value.accept(new InputNodeDisplayVisitor(this));

                }
                else
                {
                    value.accept(new InputNodeDisplayVisitor(this));
                }
            }
        }


        public Dictionary<string, IInputNode> GetInputNodes()
        {
            return this.inputNodes;
        }

        public List<IInputNode> CreateCircuit()
        {
            return null;
        }

        public Dictionary<String, IOutputNode> GetOutputNodes()
        {
            return this.outputNodes;

        }

        public Dictionary<String, INode> GetNodes()
        {
            return this.nodes;

        }

        public bool SetCircuit(string s)
        {
            inputNodes.Clear();
            outputNodes.Clear();
            nodes.Clear();

            if (s.ToLower().EndsWith(".txt"))
            {
                createNodes(s);

                if (outputNodes.Count == 0)
                {
                    output.Write("WARNING: Your circuit does not have any output nodes!");
                }

                foreach (KeyValuePair<String, INode> entry in nodes)
                {
                    if(entry.GetOutputNodes().size() < 1 && !entry.IsOutput())
                    {
                        output.Write("WARING: Node " + entry.GetLiteralName() + " does not have any output nodes!");
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public void ShowCircuit()
        {
            foreach (KeyValuePair<String, INode> entry in nodes)
            {
                String outputs = "";

                foreach (INode n in entry.GetOutputNodes())
                {
                    outputs += n.GetLiteralName() + "(" + n.GetName() + "), ";
                }
                
                if (entry.GetOutputNodes().size() < 1)
                {
                    outputs = "FINAL.";
                }
                else
                {
                    outputs = outputs.Substring(0, outputs.Length - 2);
                    outputs = outputs + ".";
                }

                String circuitString = "NODE: " + entry.GetLiteralName() + "(" + entry.GetName() + ") - OUTPUT: " + outputs;

                output.Write(circuitString);
            }
        }

        public void Start()
        {
            //todo
            foreach (KeyValuePair<String, INode> entry in nodes)
            {
                entry.ClearValues();
            }


            long start_time = NanoTime();

            for (String s : inputNodes.keySet())
            {
                inputNodes.get(s).doAction();
            }

            long end_time = NanoTime();

            output.write("Circuit completed in " + (end_time - start_time) + " nanoseconds.");

            for (String s : nodes.keySet())
            {
                if (!nodes.get(s).didWork())
                {
                    output.write("WARING: Node " + nodes.get(s).getLiteralName() + " did not work correctly!");
                }
            }
        }

        public long NanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}

