using System;
using System.Collections.Generic;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace EMUlsifier
{
	public static class ScraperController
	{
		public static List<CompiledCode> scrapers = new List<CompiledCode> ();
		public static CompiledCode activeScraper;

		private static ScriptEngine engine = Python.CreateEngine();
		private static ScriptScope scope;

		private const string SCRAPER_FOLDER = @"scrapers";

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
			engine.SetSearchPaths (paths);

			DirectoryInfo dirInfo = new DirectoryInfo (SCRAPER_FOLDER);
			foreach (FileInfo file in dirInfo.GetFiles())
				if (file.Extension == ".py")
					CreateScraper (file);

			if (scrapers.Count > 0)
				activeScraper = scrapers [0];
		}


		public static Dictionary<string, string> Search(string title, string system)
		{
			//dynamic result = engine.Operations.InvokeMember (activeScraper, "search", new string[2] {title, system});
			Console.WriteLine ("Active Scraper:{0}", activeScraper);
			//Console.WriteLine (result);
			return new Dictionary<string, string> ();
		}

	}
}

