using System;
using System.Collections.Generic;

namespace EMUlsifier
{
	public class Emulator
	{
		public string name;
		public string path;
		public string args;
		public string system;
		public string romFolder;
		public List<Game> games = new List<Game>();

		public Emulator ()
		{
		}

	}
}

