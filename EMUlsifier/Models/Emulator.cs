using System;
using System.Collections.Generic;
using System.IO;

namespace EMUlsifier
{
	/// <summary>
	/// Represents an emulator.
	/// Provides all methods and properties needed to launch a given game.
	/// </summary>
	public class Emulator
	{
		/// <summary>
		/// Display name of the emulator
		/// </summary>
		public string name;
		/// <summary>
		/// Path the the emulator executable
		/// </summary>
		public string path;
		/// <summary>
		/// Launch arguments for the emulator
		/// </summary>
		public string args = "%ROM%";
		/// <summary>
		/// The system that the emulator emulates
		/// </summary>
		public string system = Core.SystemTypes.Systems[0];
		/// <summary>
		/// The path to the folder that contains the roms for the emulator
		/// </summary>
		public string romFolder;
		/// <summary>
		/// The file mask to use when searching for game files in the rom folder
		/// </summary>
		public List<string> romMasks = new List<string> ();
		/// <summary>
		/// The list of games in the rom folder.
		/// </summary>
		public List<Game> games = new List<Game>();

		public Emulator ()
		{
		}

		/// <summary>
		/// Checks to see if the given file already exists in the library.
		/// </summary>
		/// <returns><c>true</c>, if file exists in the library, <c>false</c> otherwise.</returns>
		/// <param name="file">File.</param>
		protected bool CheckFile(FileInfo file)
		{
			foreach (Game game in games)
				if (game.filePath == file.FullName)
					return true;
			return false;
		}

		/// <summary>
		/// Creates a game based upon the given file.
		/// Information on the game will be sparse to begin with, but after scraping should fill in nicely
		/// </summary>
		/// <param name="file">File.</param>
		protected void CreateGame(FileInfo file)
		{
			Game game = new Game ()
			{
				title = file.Name,
				filePath = file.FullName
			};
			games.Add (game);
		}

		/// <summary>
		/// Scans the rom folder and adds games not already in the library
		/// </summary>
		public void UpdateGamesList()
		{
			DirectoryInfo dirInfo = new DirectoryInfo (romFolder);
			foreach (FileInfo file in dirInfo.GetFiles())
			{
				if (romMasks.Count == 0 || romMasks.Contains (file.Extension))
				if (!CheckFile (file))
						CreateGame (file);
			}
		}

	}
}

