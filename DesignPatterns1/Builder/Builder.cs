using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Factory;
using DesignPatterns1.Repository;

namespace DesignPatterns1.Builder
{
    public abstract class Builder
    {
		protected Circuit _circuitToBuild;
		protected CircuitDataRepository _circuitDataRepository;

		protected Builder(CircuitDataRepository circuitDataRepository) {
			this._circuitToBuild = new Circuit();
			_circuitDataRepository = circuitDataRepository;
		}

		public abstract void BuildEdges();

		public abstract void BuildInputNodes();

		public abstract void BuildGridNodes();

		public abstract void BuildOutputNodes();

		public Circuit GetResult() {
			return _circuitToBuild;
		}
    }
}
