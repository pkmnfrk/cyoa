using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	class Action {
		public string Text { get; set; }
		public Page Page { get; set; }

		public Conditional Conditional { get; set; }

		public bool IsAvailable {
			get {
				if (Conditional == null) return true;

				return Conditional.Evaluate();
			}
		}
	}
}
