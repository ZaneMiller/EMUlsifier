using System;
using Gtk;
using Gdk;

namespace EMUlsifier
{
	public partial class IndeterminateProgressDialog : Gtk.Dialog
	{
		private const uint PULSE_RATE = 100;

		public IndeterminateProgressDialog (string title, string message, bool useMarkup = false, Pixbuf pixbuf = null) : base()
		{
			this.Build ();
			this.Title = title;
			IndeterminateProgressMessage.Text = message;
			IndeterminateProgressMessage.UseMarkup = useMarkup;
			if (pixbuf != null)
				IndeterminateProgressDialogIcon.Pixbuf = pixbuf;

			GLib.Timeout.Add(PULSE_RATE, new GLib.TimeoutHandler(delegate { IndeterminateProgressDialogBar.Pulse (); return true; }));
		}


	}
}

