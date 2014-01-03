using System;

namespace EMUlsifier
{
	public partial class GameSearchNameEntryDialog : Gtk.Dialog
	{

		public string searchTerm;

		public GameSearchNameEntryDialog (string defaultName)
		{
			this.Build ();
			GameNameEntry.Text = defaultName;
		}

		protected void GameNameOnChange (object sender, EventArgs e)
		{
			searchTerm = GameNameEntry.Text;
			buttonOk.Sensitive = !string.IsNullOrWhiteSpace (searchTerm);
		}
	}
}

