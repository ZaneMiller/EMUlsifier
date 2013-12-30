using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

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


		public static List<Tuple<string, string>> Search(string title, string system)
		{
			List<Tuple<string, string>> searchResults = new List<Tuple<string, string>> ();
			dynamic result = activeScraper.search (title, system);
			foreach (dynamic i in result)
				searchResults.Add(Tuple.Create(i, result[i]));
			return searchResults;
		}

	}
}

