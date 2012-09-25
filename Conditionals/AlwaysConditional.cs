using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	class AlwaysConditional : Conditional {
		public override bool Evaluate() {
			return true;
		}
	}
}
