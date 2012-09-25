using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CYOA {
	class Page {
		public string ID { get; set; }
		public TMLDoc Body { get; set; }

		public List<Action> Actions { get; private set; }

		public Page() {
			this.Actions = new List<Action>();
		}

		internal static Page Load(XElement p) {
			Page ret = new Page();

			ret.ID = p.Attribute("id").Value;
			ret.Body = new TMLDoc(p.Element(XName.Get("body", Adventure.NS)));

			return ret;
		}
	}
}
