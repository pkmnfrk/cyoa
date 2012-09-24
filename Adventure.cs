using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CYOA {
	class Adventure {
		public static readonly string NS = "http://mike-caron.com/cyoa";

		public Dictionary<string, Page> Pages { get; private set; }

		public Page Start { get; set; }

		public Adventure() {
			Pages = new Dictionary<string, Page>();
		}

		private void Load(XElement doc) {
			foreach (var p in doc.Element(XName.Get("pages", NS)).Elements(XName.Get("page", NS))) {
				Page page = Page.Load(p);

				if (Pages.ContainsKey(page.ID)) throw new ApplicationException("Duplicate page ID " + page.ID);

				Pages[page.ID] = page;
			}
			var start = doc.Element(XName.Get("start", NS));

			if (start == null) throw new ApplicationException("start page is missing");

			var startp = start.Value;
			if (!Pages.ContainsKey(startp)) throw new ApplicationException("start page is undefined");

			Start = Pages[startp];
		}

		public static Adventure Load(string file) {
			XDocument doc = XDocument.Load(file);

			if (doc.Root.Name != XName.Get("cyoa", NS)) {
				throw new ApplicationException("That document is not an adventure document");
			}

			Adventure ret = new Adventure();

			ret.Load(doc.Root);

			return ret;
		}

		
	}
}
