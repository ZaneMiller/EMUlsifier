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
	/// Fills the values into the emulator browser tree
	/// </summary>
	public void UpdateEmulatorTree()
	{
		ListStore emulatorListStore = new ListStore (typeof(Emulator));
		foreach(Emulator emu in EmulatorController.emulators.OrderBy(o=>o.name))
			emulatorListStore.AppendValues (emu);
		EmulatorTreeView.Model = emulatorListStore;
	}

	/// <summary>
	/// Fills values into the game browser tree
	/// </summary>
	/// <param name="games">Games.</param>
	protected void UpdateGameTree()
	{
		activeEmulator.UpdateGamesList ();
		ListStore gameListStore = new ListStore (typeof(Game));
		foreach(Game game in activeEmulator.games.OrderBy (o => o.title))
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
		{
			activeEmulator = (Emulator)model.GetValue (iter, 0);
			UpdateGameTree ();
			emuEditAction.Sensitive = true;
			emuRemoveAction.Sensitive = true;
		}
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
			UpdateEmulatorTree ();
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
			UpdateEmulatorTree ();
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
				UpdateGameView();
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

	/// <summary>
	/// Called when the selection in the game treeview is changed
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void GamesTreeOnCursorChange (object sender, EventArgs e)
	{
		TreeModel model;
		TreeIter iter;
		if ((sender as TreeView).Selection.GetSelected (out model, out iter))
		{
			activeGame = (Game)model.GetValue (iter, 0);
			UpdateGameTree ();
			//TODO: EditGameAction.Sensitive = true;
			ScrapeGameAction.Sensitive = true;
			UpdateGameView ();
		}
	}

	/// <summary>
	/// Updates the game view.
	/// </summary>
	protected void UpdateGameView()
	{
		GameTitleLabel.Text = string.Format ("<b><big>{0}</big></b>", activeGame.title);
		//TODO: Game art
		//Description
		if (!string.IsNullOrWhiteSpace(activeGame.description)) {
			GameDescriptionLabel.Text = activeGame.description;
			GameDescriptionLabel.Visible = true;
		} else
			GameDescriptionLabel.Visible = false;
		//Genres
		if (activeGame.genres.Count > 0) {
			GameGeneresLabel.Text = "<b>Genres:</b>";
			foreach (string g in activeGame.genres)
				GameGeneresLabel.Text += string.Format (" {0}", g);
			GameGeneresLabel.Visible = true;
		} else
			GameGeneresLabel.Visible = false;
		//Release Date
		if (activeGame.releaseDate != null) {
			GameReleaseDateLabel.Text = string.Format("<b>Release Date:</b> {0}",activeGame.releaseDate.ToLongDateString ());
			GameReleaseDateLabel.Visible = true;
		} else
			GameReleaseDateLabel.Visible = false;
		//Rating
		if (!string.IsNullOrWhiteSpace (activeGame.rating)) {
			GameRatingLabel.Text = string.Format ("<b>Rating:</b> {0}", activeGame.rating);
			GameRatingLabel.Visible = true;
		} else
			GameRatingLabel.Visible = false;
		//Publisher
		if (!string.IsNullOrWhiteSpace (activeGame.publisher)) {
			GamePublisherLabel.Text = string.Format ("<b>Publisher:</b> {0}", activeGame.publisher);
			GamePublisherLabel.Visible = true;
		} else
			GamePublisherLabel.Visible = false;
		//Developer
		if (!string.IsNullOrWhiteSpace (activeGame.developer)) {
			GameDeveloperLabel.Text = string.Format ("<b>Developer:</b> {0}", activeGame.developer);
			GameDeveloperLabel.Visible = true;
		} else
			GameDeveloperLabel.Visible = false;
		//Community Rating
		if (activeGame.communityRating > 0) {
			GameCommunityRatingLabel.Text = string.Format ("<b>Community Rating:</b> {0}", activeGame.communityRating);
			GameCommunityRatingLabel.Visible = true;
		} else
			GameCommunityRatingLabel.Visible = false;
		//Box Art
		if (!string.IsNullOrWhiteSpace (activeGame.boxArtPath)) {
			Pixbuf pixbuf = new Pixbuf (activeGame.boxArtPath);
			GameBoxArtImage.Pixbuf = pixbuf;
			GameBoxArtImage.Visible = true;
		} else
			GameBoxArtImage.Visible = false;

		//For some reason we have to reset this to true for all controlls
		GameTitleLabel.UseMarkup = true;
		GameGeneresLabel.UseMarkup = true;
		GameReleaseDateLabel.UseMarkup = true;
		GameRatingLabel.UseMarkup = true;
		GamePublisherLabel.UseMarkup = true;
		GameDeveloperLabel.UseMarkup = true;
		GameCommunityRatingLabel.UseMarkup = true;
	}
}






