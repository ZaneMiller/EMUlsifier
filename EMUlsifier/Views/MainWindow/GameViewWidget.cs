using System;
using Gdk;

namespace EMUlsifier
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class GameViewWidget : Gtk.Bin
	{

		private Game _model;
		public Game Model { get{ return _model; } set{ _model = value; UpdateView(); }}

		//Artwork
		private const float BOXART_PADDING = 0.5f;
		private int widgetWidth;
		private Pixbuf bannerArt;
		private Pixbuf boxArt;

		public GameViewWidget ()
		{
			this.Build ();
		}

		protected void ScaleImages ()
		{
			if (Model == null)
				return;
			//Box Art
			if (boxArt != null)
			{
				float boxRatio = (float)widgetWidth / (float)boxArt.Width;
				int boxW = (int)Math.Round ((boxArt.Width * boxRatio) * BOXART_PADDING);
				int boxH = (int)Math.Round ((boxArt.Height * boxRatio) * BOXART_PADDING);
				GameBoxArtImage.Pixbuf = boxArt.ScaleSimple (boxW, boxH, InterpType.Bilinear);
			}
			//Banner Art
			if (bannerArt != null)
			{
				float bannerRatio = (float)widgetWidth / (float)bannerArt.Width;
				int bannerW = (int)Math.Round (bannerArt.Width * bannerRatio);
				int bannerH = (int)Math.Round (bannerArt.Height * bannerRatio);
				GameBannerImage.Pixbuf = bannerArt.ScaleSimple (bannerW, bannerH, InterpType.Bilinear);
			}
		}

		/// <summary>
		/// Updates the view.
		/// </summary>
		protected void UpdateView()
		{
			//If no model is set
			if (Model == null)
			{
				bannerArt = null;
				boxArt = null;
				return;
			}
			GameTitleLabel.Text = string.Format ("<b><big>{0}</big></b>", Model.title);
			//TODO: Game art
			//Description
			if (!string.IsNullOrWhiteSpace(Model.description)) {
				GameDescriptionTextView.Buffer.Text = Model.description;
				GameDescriptionTextView.Visible = true;
			} else
				GameDescriptionTextView.Visible = false;
			//Genres
			if (Model.genres.Count > 0) {
				GameGeneresLabel.Text = "<b>Genres:</b>";
				foreach (string g in Model.genres)
					GameGeneresLabel.Text += string.Format (" {0}", g);
				GameGeneresLabel.Visible = true;
			} else
				GameGeneresLabel.Visible = false;
			//Release Date
			if (Model.releaseDate != null) {
				GameReleaseDateLabel.Text = string.Format("<b>Release Date:</b> {0}",Model.releaseDate.ToLongDateString ());
				GameReleaseDateLabel.Visible = true;
			} else
				GameReleaseDateLabel.Visible = false;
			//Rating
			if (!string.IsNullOrWhiteSpace (Model.rating)) {
				GameRatingLabel.Text = string.Format ("<b>Rating:</b> {0}", Model.rating);
				GameRatingLabel.Visible = true;
			} else
				GameRatingLabel.Visible = false;
			//Publisher
			if (!string.IsNullOrWhiteSpace (Model.publisher)) {
				GamePublisherLabel.Text = string.Format ("<b>Publisher:</b> {0}", Model.publisher);
				GamePublisherLabel.Visible = true;
			} else
				GamePublisherLabel.Visible = false;
			//Developer
			if (!string.IsNullOrWhiteSpace (Model.developer)) {
				GameDeveloperLabel.Text = string.Format ("<b>Developer:</b> {0}", Model.developer);
				GameDeveloperLabel.Visible = true;
			} else
				GameDeveloperLabel.Visible = false;
			//Community Rating
			if (Model.communityRating > 0) {
				GameCommunityRatingLabel.Text = string.Format ("<b>Community Rating:</b> {0}", Model.communityRating);
				GameCommunityRatingLabel.Visible = true;
			} else
				GameCommunityRatingLabel.Visible = false;
			//Banner Art
			if (!string.IsNullOrWhiteSpace (Model.bannerArtPath)) {
				Pixbuf pixbuf = new Pixbuf (Model.bannerArtPath);
				GameBannerImage.Visible = true;
				bannerArt = pixbuf;
			} else
			{
				bannerArt = null;
				GameBannerImage.Visible = false;
			}
			//Box Art
			if (!string.IsNullOrWhiteSpace (Model.boxArtPath)) {
				Pixbuf pixbuf = new Pixbuf (Model.boxArtPath);
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
	}
}

