using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace EMUlsifier
{
	public static class EmulatorController
	{
		public static List<Emulator> emulators = new List<Emulator> ();

		private static XmlSerializer xs = new XmlSerializer(typeof(List<Emulator>));

		private const string LIBRARY_FILE_NAME = "Library.xml";

		public static void LoadLibrary()
		{
			if (File.Exists (LIBRARY_FILE_NAME))
				using (FileStream fs = new FileStream (LIBRARY_FILE_NAME, FileMode.OpenOrCreate))
					emulators = (List<Emulator>)xs.Deserialize (fs);
		}

		public static void SaveLibrary()
		{
			using (StreamWriter sw = new StreamWriter(LIBRARY_FILE_NAME, false))
				xs.Serialize(sw, emulators);
		}

	}
}

