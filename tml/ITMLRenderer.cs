using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	interface ITMLRenderer {
		string Render(Player p, TMLDoc doc);
	}
}
