using System;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Components.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP1Tests.ComponentTests
{
    [TestClass]
    public class NodeTests : Node
    {
        [TestMethod]
        public void Reset_NodeInputsAndResultAreSetToDefaultValues_ShouldSetNodeInputsAndResultToDefaultValues()
        {
            //Arrange
            Node node = new Node();
            node.Inputs.Add(true);
            node.Result = true;

            //Assert
            Assert.IsTrue(node.Inputs.Count == 1);

            //Act
            node.Reset();

            //Assert
            Assert.IsTrue(node.Inputs.Count == 0);
           // Assert.IsTrue(node.Result = false);
        }

        [TestMethod]
        public void CanBeResolved_NodeReceivedInputMatchingEntries_ShouldReturnTrue()
        {
            //Arrange
            Node node = new Node();
            node.IncrementEntries();
            node.IncrementEntries();


            //Assert
            Assert.IsFalse(node.CanBeResolved());

            //Act
            node.ReceiveInput(true);
            node.ReceiveInput(true);
            bool result = node.CanBeResolved();
           
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeResolved_NodeReceivedInputNotMatchingEntries_ShouldReturnFalse()
        {
            //Arrange
            Node node = new Node();
            node.IncrementEntries();
            node.IncrementEntries();

            node.ReceiveInput(true);
            node.ReceiveInput(true);

            //Assert
            Assert.IsTrue(node.CanBeResolved());

            //Act
            node.IncrementEntries();
            bool result = node.CanBeResolved();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReceiveInput_NodeReceivesInput_InputsShouldHaveNewAddition()
        {
            //Arrange
            Node node = new Node();

            //Assert
            Assert.IsTrue(node.Inputs.Count == 0);

            //Act
            node.ReceiveInput(true);

            //Assert
            Assert.IsTrue(node.Inputs.Count == 1 && node.Inputs.Contains(true));
        }

        [TestMethod]
        public void AddEdge_NodeReceivesEdge_OutputEdgesShouldHaveNewAddition()
        {
            //Arrange
            Node node = new Node();
            Node nodeToConnectTo = new Node();

            Edge edge = new Edge(node, nodeToConnectTo);

            //Assert
            Assert.IsTrue(node.OutputEdges.Count == 0);

            //Act
            node.AddEdge(edge);

            //Assert
            Assert.IsTrue(node.OutputEdges.Count == 1);
        }

        [TestMethod]
        public void AddEdge_NodeReceivesNullEdge_OutputEdgesShouldNotUpdate()
        {
            //Arrange
            Node node = new Node();

            //Act
            node.AddEdge(null);

            //Assert
            Assert.IsTrue(node.OutputEdges.Count == 0);
        }
    }
}
