using System;
using Gtk;
using System.Collections.Generic;

namespace EMUlsifier
{
	public partial class GameSearchResultDialog : Gtk.Dialog
	{

		private List<Tuple<string, string>> result;
		public Tuple<string, string> selected;

		public GameSearchResultDialog (List<Tuple<string, string>> result)
		{
			this.Build ();
			this.result = result;
			CreateTreeView ();
		}

		/// <summary>
		/// Creates the tree view based upon the search results.
		/// </summary>
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

		/// <summary>
		/// Renders the name of the search result in the treeview
		/// </summary>
		/// <param name="column">Column.</param>
		/// <param name="cell">Cell.</param>
		/// <param name="model">Model.</param>
		/// <param name="iter">Iter.</param>
		protected void RenderGameName (TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			Tuple<string,string> game = (Tuple<string, string>)model.GetValue (iter, 0);
			(cell as CellRendererText).Text = game.Item2;
		}

		/// <summary>
		/// Called when a selection is made in the treeview
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void GameSearchResultOnCursorChange (object sender, EventArgs e)
		{
			TreeModel model;
			TreeIter iter;
			if ((sender as TreeView).Selection.GetSelected (out model, out iter))
			{
				selected = (Tuple<string, string>)model.GetValue (iter, 0);
				GameSearchResultOkButton.Sensitive = true;
			}
		}
	}
}

