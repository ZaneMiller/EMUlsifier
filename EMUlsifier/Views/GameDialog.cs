using System;
using System.Linq;
using Gtk;
using Gdk;

namespace EMUlsifier
{
	public partial class GameDialog : Gtk.Dialog
	{

		protected Game game;
		protected int width;
		protected Pixbuf bannerArt;
		protected Pixbuf boxArt;

		public GameDialog (Game game)
		{
			this.Build ();
			this.game = game;
			FillInputs ();
		}

		protected void FillInputs ()
		{
			GameTitleEntry.Text = game.title;
			if (game.genres.Count > 0)
				GenresEntry.Text = String.Join (",", game.genres.Select (x => x));
			if (game.releaseDate != null)
				ReleaseDateEntry.Text = game.releaseDate.ToShortDateString ();
			DescriptionTextView.Buffer.Text = game.description;
			RatingEntry.Text = game.rating;
			DeveloperEntry.Text = game.developer;
			PublisherEntry.Text = game.publisher;
			BannerArtPathEntry.Text = game.bannerArtPath;
			BoxArtPathEntry.Text = game.boxArtPath;
		}

		protected void GameTitleEntryOnChange (object sender, EventArgs e)
		{
			buttonOk.Sensitive = !string.IsNullOrWhiteSpace (GameTitleEntry.Text);
		}

		protected string GetFilePath ()
		{
			string path = "";
			FileChooserDialog fcd = new FileChooserDialog ("Select Artwork",
				                        this, 
				                        FileChooserAction.Open,
				                        "Select", ResponseType.Accept,
				                        "Cancel", ResponseType.Cancel);
			if ((ResponseType)fcd.Run () == ResponseType.Accept)
				path = fcd.Filename;
			fcd.Destroy ();
			return path;
		}

		protected void BannerArtBrowserOnClick (object sender, EventArgs e)
		{
			string path = GetFilePath ();
			if (!string.IsNullOrWhiteSpace (path))
				BannerArtPathEntry.Text = path;
		}


		public void UpdateGame()
		{
			game.title = GameTitleEntry.Text;
			game.genres = GenresEntry.Text.Split (',').ToList ();
			if (!string.IsNullOrWhiteSpace (ReleaseDateEntry.Text))
				game.releaseDate = DateTime.Parse (ReleaseDateEntry.Text);
			game.description = DescriptionTextView.Buffer.Text;
			game.rating = RatingEntry.Text;
			game.publisher = PublisherEntry.Text;
			game.developer = DeveloperEntry.Text;
			game.boxArtPath = BoxArtPathEntry.Text;
			game.bannerArtPath = BannerArtPathEntry.Text;
		}

		protected void SizeImages ()
		{
			if (bannerArt != null)
			{
				float bannerRatio = Math.Min (1, ((float)width / (float)bannerArt.Width));
				int bannerW = (int)Math.Round (bannerArt.Width * bannerRatio);
				int bannerH = (int)Math.Round (bannerArt.Height * bannerRatio);
				BannerPreview.Pixbuf = bannerArt.ScaleSimple (bannerW, bannerH, InterpType.Bilinear);
			}
			if (boxArt != null)
			{
				float boxRatio = Math.Min (1, ((float)width / (float)boxArt.Height));
				int boxW = (int)Math.Round (boxArt.Width * boxRatio);
				int boxH = (int)Math.Round (boxArt.Height * boxRatio);
				BoxArtPreview.Pixbuf = boxArt.ScaleSimple (boxW, boxH, InterpType.Bilinear);
			}
		}

		protected void BannerArtPathOnchange (object sender, EventArgs e)
		{
			bannerArt = new Pixbuf (BannerArtPathEntry.Text);
			SizeImages ();
		}

		protected void BoxArtPathOnChange (object sender, EventArgs e)
		{
			boxArt = new Pixbuf (BoxArtPathEntry.Text);
			SizeImages ();
		}

		protected void GameDialogOnSizeAllocate (object o, SizeAllocatedArgs args)
		{
			width = args.Allocation.Width;
			SizeImages ();
		}
	}
}

