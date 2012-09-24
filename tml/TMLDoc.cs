using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CYOA {
	class TMLDoc {
		public static readonly string NS = "http://mike-caron.com/cyoa/tml";

		public XElement Doc { get; set; }

		public TMLDoc(XElement d) {
			Doc = d;
		}
	}
}
