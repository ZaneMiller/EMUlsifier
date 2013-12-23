using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace EMUlsifier
{
	public static class EmulatorController
	{
		public static List<Emulator> emulators = new List<Emulator> ();

		private static XmlSerializer xs = new XmlSerializer(typeof(emulators));

		private const string LIBRARY_FILE_NAME = "Library.xml";

		private static void LoadEmulators()
		{
			using (FileStream fs = new FileStream (LIBRARY_FILE_NAME, FileMode.Open))
				emulators = xs.Deserialize (fs);
		}

		public static bool SaveEmulators(out Exception error)
		{
			try
			{
				FileStream fs = new FileStream (LIBRARY_FILE_NAME, FileMode.OpenOrCreate);
				xs.Serialize (fs, emulators);
			}
			catch (Exception e)
			{
				error = e;
				return false;
			}
			return true;
		}

	}
}

