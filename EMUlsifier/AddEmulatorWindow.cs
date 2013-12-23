using System;
using Gtk;

namespace EMUlsifier
{
	public partial class AddEmulatorWindow : Gtk.Window
	{
		public AddEmulatorWindow () : 
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

