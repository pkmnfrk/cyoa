using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CYOA {
	class TMLConsoleRenderer : ITMLRenderer {
		public string Render(Player p, TMLDoc d) {
			StringBuilder ret = new StringBuilder();

			var doc = d.Doc;

			foreach (var tag in doc.Elements()) {
				if (tag.Name == XName.Get("p", TMLDoc.NS)) {
					RenderP(p, ret, tag);
				}
			}

			return ret.ToString();
		}

		private void RenderP(Player p, StringBuilder ret, XElement ptag) {
			foreach (var t in ptag.Nodes()) {
				if (t.NodeType == System.Xml.XmlNodeType.Element) {
					var tag = (XElement)t;
					if (tag.Name == XName.Get("p", TMLDoc.NS)) {
						throw new ApplicationException("Cannot nest p tags");
					}

					if (tag.Name == XName.Get("br", TMLDoc.NS)) {
						RenderBR(p, ret, tag);
					}
				}

				if (t.NodeType == System.Xml.XmlNodeType.Text) {
					ret.Append(((XText)t).Value);
				}
			}

			ret.AppendLine();
			ret.AppendLine();
		}

		private void RenderBR(Player p, StringBuilder ret, XElement t) {
			ret.AppendLine();
		}
	}
}
