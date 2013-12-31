using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Net;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Gdk;

namespace EMUlsifier
{
	public static class ScraperController
	{
		public static List<dynamic> scrapers = new List<dynamic> ();
		public static dynamic activeScraper;

		private static ScriptEngine engine = Python.CreateEngine();
		private static ScriptScope scope;

		private static readonly string SCRAPER_FOLDER =  Path.GetDirectoryName (Assembly.GetEntryAssembly ().Location) + Path.DirectorySeparatorChar + "scrapers";
		private static readonly string PY_LIBRARY_FOLDERS = SCRAPER_FOLDER + Path.DirectorySeparatorChar + "libs";

		private static readonly string ARTWORK_FOLDER = Path.GetDirectoryName (Assembly.GetEntryAssembly ().Location) + Path.DirectorySeparatorChar + "artwork";

		private enum ArtworkType {Banner, BoxArt};

		static ScraperController ()
		{
			//var ipy = Python.CreateRuntime ();
			//ipy.UseFile (@"scrapers\EMUlsifierScrapers");
			UpdateScrapers ();
		}

		/// <summary>
		/// Creates a scraper from the given Python file.
		/// </summary>
		/// <param name="file">File.</param>
		private static void CreateScraper(FileInfo file)
		{
			ScriptSource source = engine.CreateScriptSourceFromFile (file.FullName);
			CompiledCode compiled = source.Compile ();

			compiled.Execute (scope);

			try
			{
				scrapers.Add(engine.Operations.Invoke (scope.GetVariable ("Scraper")));
			}
			catch (Exception e)
			{
				//TODO: Handle this
				Console.WriteLine (e.Message);
			}

		}

		/// <summary>
		/// Updates the list of scrapers. This is only called once per program instance.
		/// </summary>	
		private static void UpdateScrapers()
		{
			scope = engine.CreateScope ();
			//Add the default path
			var paths = engine.GetSearchPaths ();
			paths.Add (@"C:\Python27\Lib");
			paths.Add (PY_LIBRARY_FOLDERS);
			engine.SetSearchPaths (paths);

			DirectoryInfo dirInfo = new DirectoryInfo (SCRAPER_FOLDER);
			foreach (FileInfo file in dirInfo.GetFiles())
				if (file.Extension == ".py")
					CreateScraper (file);

			if (scrapers.Count > 0)
				activeScraper = scrapers [0];
		}

		/// <summary>
		/// Search the specified title using the set scraper.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="system">System.</param>
		public static List<Tuple<string, string>> Search(string title, string system)
		{
			List<Tuple<string, string>> searchResults = new List<Tuple<string, string>> ();
			dynamic result = activeScraper.search (title, system);
			foreach (dynamic i in result)
				searchResults.Add(Tuple.Create(i, result[i]));
			return searchResults;
		}

		/// <summary>
		/// Updates a game from a search result from a scraper
		/// </summary>
		/// <param name="game">Game.</param>
		/// <param name="searchId">Search identifier.</param>
		public static void UpdateGame(Game game, string searchId)
		{
			dynamic result = activeScraper.getInfo (searchId);
			//{"title" : None, "genres" : [], "releaseDate" : None, "description" : None, "rating" : None, "publisher" : None, "developer" : None, "communityRating" : None, "boxArt" : None, "bannerArt" : None}
			foreach (string key in result)
			{
				dynamic value = result [key];
				if (value == null) //Skip null values
					continue;
				switch (key)
				{
					case "title":
						game.title = value;
						break;
					case "generes":
						List<string> genres = new List<string> ();
						foreach (string genre in value)
							genres.Add (genre);
						game.genres = genres;
						break;
					case "releaseDate":
						game.releaseDate = DateTime.Parse (value);
						break;
					case "description":
						game.description = value;
						break;
					case "rating":
						game.rating = value;
						break;
					case "publisher":
						game.publisher = value;
						break;
					case "developer":
						game.developer = value;
						break;
					case "communityRating":
						game.communityRating = value;
						break;
					case "boxArt":
						DownloadArtwork (value, game, ArtworkType.BoxArt);
						break;
					case "bannerArt":
						DownloadArtwork (value, game, ArtworkType.Banner);
						break;
				}
			}
		}

		private static void DownloadArtwork(string url, Game game, ArtworkType artType)
		{
			WebClient webClient = new WebClient ();

			webClient.DownloadDataCompleted += (sender, e) => {
				string filename = Path.GetRandomFileName() + Path.GetExtension(url);
				string path = Path.Combine(ARTWORK_FOLDER, filename);
				File.WriteAllBytes(path, e.Result);

				if(artType == ArtworkType.Banner)
					game.bannerArtPath = path;
				else if (artType == ArtworkType.BoxArt)
					game.boxArtPath= path;
			};

			webClient.DownloadDataAsync (new Uri (url));
		}

	}
}

