using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	class OrConditional : Conditional {
		public Conditional Left { get; set; }
		public Conditional Right { get; set; }

		public override bool Evaluate() {
			bool l = true, r = true;

			if (Left != null) l = Left.Evaluate();

			if (Right != null) r = Right.Evaluate();

			return l || r;
		}
	}
}
