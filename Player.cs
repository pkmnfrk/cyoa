using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	class Player {
		public Adventure Adventure { get; private set; }
		public Page Page { get; private set; }

		public Player(Adventure adventure) {
			this.Adventure = adventure;
			this.Page = adventure.Start;
		}
	}
}
