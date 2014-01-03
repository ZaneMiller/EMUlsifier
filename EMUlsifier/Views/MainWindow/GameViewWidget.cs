using System;
using System.Diagnostics;
using Gdk;

namespace EMUlsifier
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class GameViewWidget : Gtk.Bin
	{
		protected Game gameModel;
		protected Emulator emuModel;

		//Artwork
		protected const float BOXART_PADDING = 0.5f;
		protected int widgetWidth;
		protected Pixbuf bannerArt;
		protected Pixbuf boxArt;

		public GameViewWidget ()
		{
			this.Build ();
		}

		public void SetModels(Game game, Emulator emu)
		{
			gameModel = game;
			emuModel = emu;
			UpdateView ();
		}

		protected void ScaleImages ()
		{
			if (gameModel == null)
				return;
			//Box Art
			if (boxArt != null)
			{
				float boxRatio = Math.Min(((float)widgetWidth / (float)boxArt.Width), 1.0f);
				int boxW = (int)Math.Round ((boxArt.Width * boxRatio) * BOXART_PADDING);
				int boxH = (int)Math.Round ((boxArt.Height * boxRatio) * BOXART_PADDING);
				GameBoxArtImage.Pixbuf = boxArt.ScaleSimple (boxW, boxH, InterpType.Bilinear);
			}
			//Banner Art
			if (bannerArt != null)
			{
				float bannerRatio = Math.Min(((float)widgetWidth / (float)bannerArt.Width), 1.0f);
				int bannerW = (int)Math.Round (bannerArt.Width * bannerRatio);
				int bannerH = (int)Math.Round (bannerArt.Height * bannerRatio);
				GameBannerImage.Pixbuf = bannerArt.ScaleSimple (bannerW, bannerH, InterpType.Bilinear);
			}
		}

		/// <summary>
		/// Updates the view.
		/// </summary>
		public void UpdateView()
		{
			//If no model is set
			if (gameModel == null)
			{
				bannerArt = null;
				boxArt = null;
				return;
			}
			GameTitleLabel.Text = string.Format ("<b><big>{0}</big></b>", gameModel.title);
			//TODO: Game art
			//Description
			if (!string.IsNullOrWhiteSpace(gameModel.description)) {
				GameDescriptionTextView.Buffer.Text = gameModel.description;
				GameDescriptionTextView.Visible = true;
			} else
				GameDescriptionTextView.Visible = false;
			//Genres
			if (gameModel.genres.Count > 0) {
				GameGeneresLabel.Text = "<b>Genres:</b>";
				foreach (string g in gameModel.genres)
					GameGeneresLabel.Text += string.Format (" {0}", g);
				GameGeneresLabel.Visible = true;
			} else
				GameGeneresLabel.Visible = false;
			//Release Date
			if (gameModel.releaseDate != null) {
				GameReleaseDateLabel.Text = string.Format("<b>Release Date:</b> {0}",gameModel.releaseDate.ToLongDateString ());
				GameReleaseDateLabel.Visible = true;
			} else
				GameReleaseDateLabel.Visible = false;
			//Rating
			if (!string.IsNullOrWhiteSpace (gameModel.rating)) {
				GameRatingLabel.Text = string.Format ("<b>Rating:</b> {0}", gameModel.rating);
				GameRatingLabel.Visible = true;
			} else
				GameRatingLabel.Visible = false;
			//Publisher
			if (!string.IsNullOrWhiteSpace (gameModel.publisher)) {
				GamePublisherLabel.Text = string.Format ("<b>Publisher:</b> {0}", gameModel.publisher);
				GamePublisherLabel.Visible = true;
			} else
				GamePublisherLabel.Visible = false;
			//Developer
			if (!string.IsNullOrWhiteSpace (gameModel.developer)) {
				GameDeveloperLabel.Text = string.Format ("<b>Developer:</b> {0}", gameModel.developer);
				GameDeveloperLabel.Visible = true;
			} else
				GameDeveloperLabel.Visible = false;
			//Community Rating
			if (!string.IsNullOrWhiteSpace (gameModel.communityRating)) {
				GameCommunityRatingLabel.Text = string.Format ("<b>Community Rating:</b> {0}", gameModel.communityRating);
				GameCommunityRatingLabel.Visible = true;
			} else
				GameCommunityRatingLabel.Visible = false;
			//Banner Art
			if (!string.IsNullOrWhiteSpace (gameModel.bannerArtPath)) {
				Pixbuf pixbuf = new Pixbuf (gameModel.bannerArtPath);
				GameBannerImage.Visible = true;
				bannerArt = pixbuf;
			} else
			{
				bannerArt = null;
				GameBannerImage.Visible = false;
			}
			//Box Art
			if (!string.IsNullOrWhiteSpace (gameModel.boxArtPath)) {
				Pixbuf pixbuf = new Pixbuf (gameModel.boxArtPath);
				GameBoxArtImage.Visible = true;
				boxArt = pixbuf;
			} else
			{
				GameBoxArtImage.Visible = false;
				boxArt = null;
			}

			//For some reason we have to reset this to true for all controlls
			GameTitleLabel.UseMarkup = true;
			GameGeneresLabel.UseMarkup = true;
			GameReleaseDateLabel.UseMarkup = true;
			GameRatingLabel.UseMarkup = true;
			GamePublisherLabel.UseMarkup = true;
			GameDeveloperLabel.UseMarkup = true;
			GameCommunityRatingLabel.UseMarkup = true;

			ScaleImages ();
		}

		protected void GameViewOnSizeAllocated (object o, Gtk.SizeAllocatedArgs args)
		{
			widgetWidth = args.Allocation.Width;
			ScaleImages ();
		}

		protected void LaunchGameOnClick (object sender, EventArgs e)
		{
			string args = emuModel.args.Replace (Emulator.ROM_PLACEHOLDER, gameModel.filePath);
			Console.WriteLine (emuModel.args);
			Process.Start (emuModel.path, args);
		}
	}
}

