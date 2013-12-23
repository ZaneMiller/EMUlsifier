using System;
using Gtk;
using Gdk;

namespace EMUlsifier
{
	class MainClass
	{
		public static MainWindow win;
		public static void Main (string[] args)
		{
			Application.Init ();
			win = new MainWindow ();
			win.Title = "EMUlsifier";

			/*
			Gdk.Window gwin = win.GdkWindow;
			Pixbuf pixbuf = new Pixbuf(@"artwork/FanartResidentEvil4.jpg");
			Style style = win.Style.Copy ();

			Pixmap mask;
			Pixmap pixmap;

			pixbuf.RenderPixmapAndMask (out pixmap, out mask, 150);

			style.SetBgPixmap (StateType.Normal, pixmap);

			win.Style = style;
			*/

			win.Show ();
			Application.Run ();
		}
	}
}
