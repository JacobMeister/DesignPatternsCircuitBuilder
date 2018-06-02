using System;
using System.Collections.Generic;
using System.Diagnostics;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Factory;
using DesignPatterns1.Visitor;

namespace DesignPatterns1.Controller
{
    public class CircuitDirector : IInputHandler
    {
        private Dictionary<String, IInputNode> inputNodes = new Dictionary<string, IInputNode>();
        private Dictionary<String, INode> nodes = new Dictionary<string, INode>();
        private Dictionary<String, IOutputNode> outputNodes = new Dictionary<string, IOutputNode>();
        private IOutputHandler output;
        private CircuitParser parser;

        public CircuitDirector()
        {
            
        }
        
        public void SetOutputHandler(IOutputHandler output)
        {
            this.output = output;
            this.parser = new CircuitParser(output);
        }

        public void ChangeInputNodes(List<string> temp)
        {
            foreach (string s in temp)
            {
                var value = this.inputNodes[s];
                if (value.GetName() == "INPUT_HIGH")
                {
                    value.Accept(new DisplayTextVisitor(this));
                }
                else
                {
                    value.Accept(new DisplayTextVisitor(this));
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
                parser.ParseCircuit(s);
                CreateNodes(parser.GetNodes(), parser.GetEdges());
                return true;
            }
            else
            {
                output.Write("WARING: File must have .txt extension!");
                return false;
            }
            
            //    if (outputNodes.Count == 0)
            //    {
            //        output.Write("WARNING: Your circuit does not have any output nodes!");
            //    }

            //    foreach (KeyValuePair<String, INode> entry in nodes)
            //    {
            //        if(entry.Value.GetOutputNodes().Count < 1 && !entry.Value.IsOutput())
            //        {
            //            output.Write("WARING: Node " + entry.Value.GetLiteralName() + " does not have any output nodes!");
            //        }
            //    }
            //    return true;
           

        }

        public void CreateNodes(Dictionary<String, String> nodeList, Dictionary<String, List<String>> edgeList)
        {

            //builder.build(nodeList, edgeList);

                        //should go in builder
                        //if (!nodes.ContainsKey(name))
                        //{
                        //    try
                        //    {
                        //        NodeFactory factory = new NodeFactory();
                        //        INode node = factory.CreateFromName(type);
                        //        node.SetLiteralName(name);
                        //        node.SetOutputHandler(output);

                        //        if (node.IsInput())
                        //        {
                        //            inputNodes.Add(name, (IInputNode)node);
                        //        }
                        //        else if (node.IsOutput())
                        //        {
                        //            IOutputNode newNode = (IOutputNode)node;
                        //            outputNodes.Add(name, (IOutputNode)newNode);
                        //        }
                        //        nodes.Add(name, node);
                        //    }
                        //    catch (Exception e)
                        //    {
                        //        //should stay here
                        //        output.Write("The file you have provided is invalid.\nPlease validate in order to use this product.");
                        //        //
                        //    }
                        //}
                        //else
                        //{
                        //    INode node = nodes[name];
                        //    String[] names = type.Split(',');
                        //    foreach(String z in names)
                        //    {
                        //        node.AddOutputNode(nodes[z]);
                        //        nodes[z].HeightenInputAmount();
                        //    }
                        //}
             

        }


        public void ShowCircuit()
        {
            foreach (KeyValuePair<String, INode> entry in nodes)
            {
                String outputs = "";

                foreach (INode n in entry.Value.GetOutputNodes())
                {
                    outputs += n.GetLiteralName() + "(" + n.GetName() + "), ";
                }
                
                if (entry.Value.GetOutputNodes().Count < 1)
                {
                    outputs = "FINAL.";
                }
                else
                {
                    outputs = outputs.Substring(0, outputs.Length - 2);
                    outputs = outputs + ".";
                }

                String circuitString = "NODE: " + entry.Value.GetLiteralName() + "(" + entry.Value.GetName() + ") - OUTPUT: " + outputs;

                output.Write(circuitString);
            }
        }

        public void Start()
        {
            foreach (KeyValuePair<String, INode> entry in nodes)
            {
                entry.Value.ClearValues();
            }


            long start_time = NanoTime();

            foreach (KeyValuePair<String, IInputNode> entry in inputNodes)
            {
                entry.Value.DoAction();
            }
            

            long end_time = NanoTime();

            output.Write("Circuit completed in " + (end_time - start_time) + " nanoseconds.");

            foreach (KeyValuePair<String, INode> entry in nodes)
            {
                
                if (!entry.Value.DidWork())
                {
                    output.Write("WARING: Node " + entry.Value.GetLiteralName() + " did not work correctly!");
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

