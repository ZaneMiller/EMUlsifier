using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;
using EMUlsifier;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		CreateTrees ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	/// <summary>
	/// Creates the game browser tree.
	/// </summary>
	protected void CreateTrees ()
	{
		//Create the column for the emulator list
		TreeViewColumn emulatorColumn = new TreeViewColumn ();
		CellRendererText emulatorCell = new CellRendererText ();
		emulatorColumn.PackStart (emulatorCell, true);
		emulatorColumn.SetCellDataFunc (emulatorCell, new TreeCellDataFunc (RenderEmulatorName));
		EmulatorTreeView.AppendColumn (emulatorColumn);


		//Create the column for the game list
		TreeViewColumn gameColumn = new TreeViewColumn ();
		CellRendererText gameCell = new CellRendererText ();
		gameColumn.PackStart (gameCell, true);
		gameColumn.SetCellDataFunc (gameCell, new TreeCellDataFunc (RenderGameName));
		GameTreeView.AppendColumn (gameColumn);

		UpdateEmulatorTree ();
	}

	/// <summary>
	/// Fills the values into the game browser tree
	/// </summary>
	protected void UpdateEmulatorTree()
	{
		ListStore emulatorListStore = new ListStore (typeof(Emulator));
		foreach(Emulator emu in EmulatorController.GetEmulators().OrderBy(o=>o.name))
			emulatorListStore.AppendValues (emu);
		EmulatorTreeView.Model = emulatorListStore;
	}

	protected void UpdateGameTree(List<Game> games)
	{
		ListStore gameListStore = new ListStore (typeof(Game));
		foreach(Game game in games.OrderBy (o => o.title))
			gameListStore.AppendValues (game);
		GameTreeView.Model = gameListStore;
	}

	/// <summary>
	/// Renders the name of the emulator.
	/// </summary>
	/// <param name="column">Column.</param>
	/// <param name="cell">Cell.</param>
	/// <param name="model">Model.</param>
	/// <param name="iter">Iter.</param>
	private void RenderEmulatorName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
	{
		Emulator emu = (Emulator)model.GetValue (iter, 0);
		(cell as CellRendererText).Text = emu.name;
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
			UpdateGameTree (((Emulator)model.GetValue (iter, 0)).games);
	}


	/// <summary>
	/// Opens the add emulator dialog when the button is clicked
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void AddEmulatorOnActivate (object sender, EventArgs e)
	{
		AddEmulatorWindow emuWin = new AddEmulatorWindow();
		emuWin.Show ();
	}
}


