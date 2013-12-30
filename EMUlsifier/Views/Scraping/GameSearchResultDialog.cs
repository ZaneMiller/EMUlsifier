using System;
using Gtk;
using System.Collections.Generic;

namespace EMUlsifier
{
	public partial class GameSearchResultDialog : Gtk.Dialog
	{

		private List<Tuple<string, string>> result;

		public GameSearchResultDialog (List<Tuple<string, string>> result)
		{
			this.Build ();
			this.result = result;
			CreateTreeView ();
		}

		protected void CreateTreeView ()
		{
			//Create the column for the emulator list
			TreeViewColumn gameColumn = new TreeViewColumn ();
			CellRendererText gameCell = new CellRendererText ();
			gameColumn.PackStart (gameCell, true);
			gameColumn.SetCellDataFunc (gameCell, new TreeCellDataFunc (RenderGameName));
			GameSearchResultTreeView.AppendColumn (gameColumn);


			ListStore gameListStore = new ListStore (typeof(Tuple<string, string>));

			foreach(Tuple<string, string> game in result)
				gameListStore.AppendValues (game);
			GameSearchResultTreeView.Model = gameListStore;
		}


		protected void RenderGameName (TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			Tuple<string,string> game = (Tuple<string, string>)model.GetValue (iter, 0);
			(cell as CellRendererText).Text = game.Item2;
		}

	}
}

