using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace CYOA {
	class Player {
		public static readonly string NS = "http://mike-caron.com/cyoa/save";

		public Adventure Adventure { get; private set; }
		public Page Page { get; private set; }
		public HashSet<string> Flags { get; private set; }
		
		public Player(Adventure adventure) {
			this.Adventure = adventure;
			Flags = new HashSet<string>();
		}

		public bool HasSave {
			get {
				return File.Exists(SaveFile);
			}
		}

		public string SaveFile {
			get {
				return Path.ChangeExtension(Adventure.Name, ".sav");
			}
		}

		public void LoadSave() {
			XDocument sav;
			try {
				sav = XDocument.Load(SaveFile);
			} catch {
				return;
			}

			var adv = sav.Root.Element(XName.Get("adventure", NS));
			if (adv == null || adv.Value != Adventure.Name) throw new ApplicationException("Save file does not match");

			var page = sav.Root.Element(XName.Get("page", NS));
			if (page == null) throw new ApplicationException("Page is not set");
			if (!Adventure.Pages.ContainsKey(page.Value)) throw new ApplicationException("Page does not exist");

			Page = Adventure.Pages[page.Value];

			var flags = sav.Root.Element(XName.Get("flags", NS));

			if (flags != null) {
				foreach (var f in flags.Elements()) {
					Flags.Add(f.Name.LocalName);
				}
			}
		}

		public void NewGame() {
			Page = Adventure.Start;
		}

		public void Save() {

			XElement root = new XElement(XName.Get("save", NS),
				new XElement(XName.Get("adventure", NS), Adventure.Name),
				new XElement(XName.Get("page", NS), Page.ID),
				new XElement(XName.Get("flags", NS),
					Flags.Select(s => new XElement(XName.Get(s, NS)))
				)
			);

			root.Save(SaveFile);
		}
		
	}
}
