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



			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(true);
		}
	}
}
