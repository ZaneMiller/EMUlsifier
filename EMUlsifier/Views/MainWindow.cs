using System;
using System.Threading;
using Gtk;
using Gdk;
using System.Collections.Generic;
using System.Linq;
using EMUlsifier;

public partial class MainWindow: Gtk.Window
{	

	private Emulator activeEmulator;
	private Game activeGame;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		LoadLibrary ();
		CreateTrees ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		SaveLibrary ();
		Application.Quit ();
		a.RetVal = true;
	}

	/// <summary>
	/// Saves the library.
	/// If an error occurs saving, alert the user
	/// </summary>
	protected void SaveLibrary()
	{
		Exception e = EmulatorController.SaveLibrary ();
		if (e != null)
		{
			MessageDialog errorDialog = new MessageDialog (this,
				                            DialogFlags.Modal,
				                            MessageType.Error,
				                            ButtonsType.Ok,
				                            string.Format ("An error occured while saving the library:\n{0}", e.Message));
			errorDialog.Run ();
			errorDialog.Destroy ();
		}
	}

	protected void LoadLibrary()
	{
		Exception e = EmulatorController.LoadLibrary();
		if (e != null)
		{
			MessageDialog md = new MessageDialog (this,
				DialogFlags.Modal,
				MessageType.Error,
				ButtonsType.Ok,
				string.Format ("An error occured while loading the library:\n{0}", e.Message)
			);
			md.Run ();
			md.Destroy ();
		}
	}

	/// <summary>
	/// Creates the game browser tree.
	/// </summary>
	protected void CreateTrees ()
	{
		//Create the column for the emulator list
		TreeViewColumn column = new TreeViewColumn ();
		CellRendererText cell = new CellRendererText ();
		column.PackStart (cell, true);
		column.SetCellDataFunc (cell, new TreeCellDataFunc (RenderName));
		LibraryTreeView.AppendColumn (column);

		UpdateTree ();
	}

	/// <summary>
	/// Fills the values into the emulator browser tree
	/// </summary>
	public void UpdateTree()
	{
		TreeStore listStore = new TreeStore (typeof(Emulator), typeof(Game));
		foreach (Emulator emu in EmulatorController.emulators.OrderBy(o=>o.name))
		{
			TreeIter iter = listStore.AppendValues (emu);
			foreach (Game game in emu.games)
				listStore.AppendValues (iter, game);
		}
		LibraryTreeView.Model = listStore;
	}

	/// <summary>
	/// Renders the name of the emulator.
	/// </summary>
	/// <param name="column">Column.</param>
	/// <param name="cell">Cell.</param>
	/// <param name="model">Model.</param>
	/// <param name="iter">Iter.</param>
	private void RenderName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
	{
		Type type = model.GetValue (iter, 0).GetType ();
		if (type == typeof(Emulator)) {
			Emulator emu = (Emulator)model.GetValue (iter, 0);
			(cell as CellRendererText).Text = emu.name;
		}
		else if (type == typeof(Game))
		{
			Game game = (Game)model.GetValue (iter, 0);
			(cell as CellRendererText).Text = game.title;
		}
	}

	/// <summary>
	/// Renders the name of the game.
	/// </summary>
	/// <param name="column">Column.</param>
	/// <param name="cell">Cell.</param>
	/// <param name="model">Model.</param>
	/// <param name="iter">Iter.</param>
	private void RenderGameName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
	{
		Game game = (Game)model.GetValue (iter, 0);
		(cell as CellRendererText).Text = game.title;
	}

	/// <summary>
	/// Called when an emulator is selected in the pannel
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void EmulatorOnCursorChange (object sender, EventArgs e)
	{
		TreeModel model;
		TreeIter iter;
		if ((sender as TreeView).Selection.GetSelected (out model, out iter))
		{
			object selected = model.GetValue (iter, 0);
			if (selected.GetType () == typeof(Emulator))
				OnEmulatorSelected ((Emulator)selected);
			else if (selected.GetType () == typeof(Game))
				OnGameSelected ((Game)selected);
		}
	}

	/// <summary>
	/// Called when an emulator is selected in the libaray
	/// </summary>
	/// <param name="emu">Emu.</param>
	protected void OnEmulatorSelected (Emulator emu)
	{
		activeEmulator = emu;
		activeGame = null;
		SetActionSensitivity ();
	}

	/// <summary>
	/// Called when a game is selected in the libaray
	/// </summary>
	/// <param name="game">Game.</param>
	protected void OnGameSelected(Game game)
	{
		activeEmulator = null;
		activeGame = game;
		GameView.Model = activeGame;
		SetActionSensitivity ();
	}

	protected void SetActionSensitivity ()
	{
		editAction.Sensitive = (activeEmulator != null || activeGame != null);
		removeAction.Sensitive = (activeEmulator != null && activeGame == null);
		refreshAction.Sensitive = (activeEmulator == null && activeGame != null);
	}

	/// <summary>
	/// Opens the add emulator dialog when the button is clicked
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void AddEmulatorOnActivate (object sender, EventArgs e)
	{
		EmulatorDialog ed = new EmulatorDialog (new Emulator ());
		if ((ResponseType)ed.Run () == ResponseType.Ok)
		{
			ed.UpdateEmulator ();
			EmulatorController.emulators.Add (ed.emulator);
			UpdateTree ();
		}
		ed.Destroy ();
	}

	/// <summary>
	/// Opens the dialog to edit the information for a given emulator
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void EditEmulatorButtonOnActivate (object sender, EventArgs e)
	{
		EmulatorDialog ed = new EmulatorDialog (activeEmulator);
		if ((ResponseType)ed.Run () == ResponseType.Ok)
			ed.UpdateEmulator ();
		ed.Destroy ();
	}

	/// <summary>
	/// Removes the emulator from the list, after warning the user about the implications of doing so.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void RemoveEmulatorButtonOnActivate (object sender, EventArgs e)
	{
		MessageDialog md = new MessageDialog(this,
			DialogFlags.Modal,
			MessageType.Warning,
			ButtonsType.YesNo,
			true,
			string.Format("<b>Warning!</b> Removing <i>{0}</i> will also remove all games and information associated with this emulator. Are you sure you want to continue?", activeEmulator.name)
		);
		if ((ResponseType)md.Run () == ResponseType.Yes)
		{
			EmulatorController.emulators.Remove (activeEmulator);
			UpdateTree ();
			activeEmulator = null;
		}
		md.Destroy ();
	}

	/// <summary>
	/// Called when the scrape game button is clicked in the game toolbar
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void ScrapeGameOnActivate (object sender, EventArgs e)
	{
		IndeterminateProgressDialog ipd = new IndeterminateProgressDialog ("Fetching Games", "Fetching search results for game...");

		//Start the search thread
		Thread thr = new Thread (new ThreadStart (delegate {
			//Search
			List<Tuple<string, string>> result = ScraperController.Search (activeGame.title, activeEmulator.system);
			//After search close the dialog and run the after search method
			Application.Invoke (delegate {
				ipd.Destroy ();
				AfterGameSearch (result);
			});
		}));

		thr.Start ();

		//Open the progress dialog, appears out of order, but isn't because of the above thread
		//If the cancel button is pressed, stop the search thread and destory the dialog
		if ((ResponseType)ipd.Run () == ResponseType.Cancel && thr.IsAlive)
		{
			thr.Abort ();
			ipd.Destroy ();
		}
	}

	/// <summary>
	/// Called after the search result is returned from 
	/// </summary>
	/// <param name="result">Result.</param>
	protected void AfterGameSearch(List<Tuple<string, string>> result)
	{
		if (result.Count == 0) {
			//TODO: Enter Name
		}
		else
		{
			GameSearchResultDialog gsrd = new GameSearchResultDialog (result);
			ResponseType rsp = (ResponseType)gsrd.Run ();
			gsrd.Destroy ();
			if (rsp == ResponseType.Ok)
				OnScraperGameSelect (gsrd.selected.Item1);
		}
	}


	protected void OnScraperGameSelect(string searchId)
	{
		//Create progress dialog
		IndeterminateProgressDialog ipd = new IndeterminateProgressDialog ("Fetching Game Information", "Fetching the details for the selected game");
		//Start the data fetching thread
		Thread thr = new Thread (new ThreadStart (delegate {
			//Fetch the data
			ScraperController.UpdateGame(activeGame, searchId);
			Application.Invoke(delegate {
				//Close the dialog in the main thread
				ipd.Destroy();
				GameView.Model = activeGame;
			});
		}));

		thr.Start ();

		//If cancled close the dialog and abort the thread
		if ((ResponseType)ipd.Run () == ResponseType.Cancel && thr.IsAlive)
		{
			thr.Abort ();
			ipd.Destroy ();
		}

	}
}






