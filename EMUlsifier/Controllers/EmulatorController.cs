using System;
using System.Collections.Generic;
using System.Linq;

namespace EMUlsifier
{
	public static class EmulatorController
	{
		private static List<Emulator> emulators = new List<Emulator> ();

		public static List<Emulator> GetEmulators()
		{
			Emulator emu = new Emulator ();
			emu.name = "ZSNES";
			emulators.Add (emu);

			Game game = new Game ();
			game.title = "Donkey Kong";
			emu.games.Add (game);


			emu = new Emulator ();
			emu.name = "GBA";
			emulators.Add (emu);
			game = new Game ();
			game.title = "Link's Awakening";
			emu.games.Add (game);

			return emulators;
		}

	}
}

