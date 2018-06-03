using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Circuit;

namespace DesignPatterns1.Builder
{
    public abstract class Builder
    {
		public abstract void BuildNodes(Dictionary<string, string> nameAndType);

		public abstract void BuildEdges(Dictionary<string, List<string>> nameAndConnectedNodeNames);

		public abstract Circuit GetResult();
    }
}
