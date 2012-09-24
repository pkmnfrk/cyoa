using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYOA {
	public class Program {
		static Adventure adventure;

		static Player player;

		public static void Main(string[] args) {
			adventure = Adventure.Load(args[0]);
			player = new Player(adventure);

			if (player.HasSave) {
				if (AskYN("Do you want to load your save game?", true)) {
					player.LoadSave();
				} else {
					player.NewGame();
				}
			} else {
				player.NewGame();
			}

			player.Save();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(true);
		}

		private static bool AskYN(string q, bool def) {
			int tries = 3;
			string yn;
			if (def) yn = "[Y/n]"; else yn = "[y/N]";

		again:
			Console.Write("{0} {1} ", q, yn);

			var key = Console.ReadLine();

			if (key == null) key = ""; else key = key.Trim();

			if (key == "") return def;

			if (Char.ToLower(key[0]) == 'y') return true;
			if (Char.ToLower(key[0]) == 'n') return false;

			tries--;
			if (tries == 0) {
				Console.WriteLine("Since you don't want to be serious, assuming {0}.", def ? 'Y' : 'N');
				return def;
			}
			goto again;
		}
	}
}
