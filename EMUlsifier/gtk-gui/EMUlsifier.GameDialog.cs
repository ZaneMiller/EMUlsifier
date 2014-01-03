
// This file has been generated by the GUI designer. Do not modify.
namespace EMUlsifier
{
	public partial class GameDialog
	{
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.VBox vbox3;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Image image23;
		private global::Gtk.Label label4;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment2;
		private global::Gtk.Entry GameTitleEntry;
		private global::Gtk.Label GtkLabel2;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment3;
		private global::Gtk.VBox vbox5;
		private global::Gtk.Entry GenresEntry;
		private global::Gtk.Label label5;
		private global::Gtk.Label GtkLabel3;
		private global::Gtk.Frame frame3;
		private global::Gtk.Alignment GtkAlignment4;
		private global::Gtk.Entry ReleaseDateEntry;
		private global::Gtk.Label GtkLabel4;
		private global::Gtk.Frame frame4;
		private global::Gtk.Alignment GtkAlignment5;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TextView DescriptionTextView;
		private global::Gtk.Label GtkLabel5;
		private global::Gtk.Frame frame5;
		private global::Gtk.Alignment GtkAlignment6;
		private global::Gtk.VBox vbox6;
		private global::Gtk.Entry RatingEntry;
		private global::Gtk.Label label6;
		private global::Gtk.Label GtkLabel6;
		private global::Gtk.Frame frame6;
		private global::Gtk.Alignment GtkAlignment7;
		private global::Gtk.Entry DeveloperEntry;
		private global::Gtk.Label GtkLabel7;
		private global::Gtk.Frame frame7;
		private global::Gtk.Alignment GtkAlignment8;
		private global::Gtk.Entry PublisherEntry;
		private global::Gtk.Label GtkLabel8;
		private global::Gtk.Frame frame8;
		private global::Gtk.Alignment GtkAlignment9;
		private global::Gtk.VBox vbox7;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Entry BannerArtPathEntry;
		private global::Gtk.Button button105;
		private global::Gtk.Image BannerPreview;
		private global::Gtk.Label GtkLabel10;
		private global::Gtk.Frame frame9;
		private global::Gtk.Alignment GtkAlignment11;
		private global::Gtk.VBox vbox8;
		private global::Gtk.HBox hbox5;
		private global::Gtk.Entry BoxArtPathEntry;
		private global::Gtk.Button BoxArtButton;
		private global::Gtk.Image BoxArtPreview;
		private global::Gtk.Label GtkLabel12;
		private global::Gtk.Button buttonOk;
		private global::Gtk.Button buttonCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget EMUlsifier.GameDialog
			this.Name = "EMUlsifier.GameDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("EMUlsifier - Edit Game");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child EMUlsifier.GameDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w2 = new global::Gtk.Viewport ();
			w2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(10));
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.image23 = new global::Gtk.Image ();
			this.image23.Name = "image23";
			this.image23.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("EMUlsifier.icons.1388794018_icon-game-controller-b.png");
			this.hbox3.Add (this.image23);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.image23]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b><big>Edit Game Information</big></b>");
			this.label4.UseMarkup = true;
			this.hbox3.Add (this.label4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label4]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox3.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hseparator1]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.GameTitleEntry = new global::Gtk.Entry ();
			this.GameTitleEntry.CanFocus = true;
			this.GameTitleEntry.Name = "GameTitleEntry";
			this.GameTitleEntry.IsEditable = true;
			this.GameTitleEntry.InvisibleChar = '●';
			this.GtkAlignment2.Add (this.GameTitleEntry);
			this.frame1.Add (this.GtkAlignment2);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("Title:");
			this.frame1.LabelWidget = this.GtkLabel2;
			this.vbox3.Add (this.frame1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GenresEntry = new global::Gtk.Entry ();
			this.GenresEntry.CanFocus = true;
			this.GenresEntry.Name = "GenresEntry";
			this.GenresEntry.IsEditable = true;
			this.GenresEntry.InvisibleChar = '●';
			this.vbox5.Add (this.GenresEntry);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GenresEntry]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Sensitive = false;
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Comma-separated list of genres (i.e. Action, Adventure, etc.)");
			this.vbox5.Add (this.label5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.label5]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.GtkAlignment3.Add (this.vbox5);
			this.frame2.Add (this.GtkAlignment3);
			this.GtkLabel3 = new global::Gtk.Label ();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("Genres:");
			this.frame2.LabelWidget = this.GtkLabel3;
			this.vbox3.Add (this.frame2);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame2]));
			w14.Position = 3;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.ReleaseDateEntry = new global::Gtk.Entry ();
			this.ReleaseDateEntry.CanFocus = true;
			this.ReleaseDateEntry.Name = "ReleaseDateEntry";
			this.ReleaseDateEntry.IsEditable = true;
			this.ReleaseDateEntry.InvisibleChar = '●';
			this.GtkAlignment4.Add (this.ReleaseDateEntry);
			this.frame3.Add (this.GtkAlignment4);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("Release Date:");
			this.frame3.LabelWidget = this.GtkLabel4;
			this.vbox3.Add (this.frame3);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame3]));
			w17.Position = 4;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame4 = new global::Gtk.Frame ();
			this.frame4.Name = "frame4";
			this.frame4.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame4.Gtk.Container+ContainerChild
			this.GtkAlignment5 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment5.Name = "GtkAlignment5";
			this.GtkAlignment5.LeftPadding = ((uint)(12));
			// Container child GtkAlignment5.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.DescriptionTextView = new global::Gtk.TextView ();
			this.DescriptionTextView.CanFocus = true;
			this.DescriptionTextView.Name = "DescriptionTextView";
			this.DescriptionTextView.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow1.Add (this.DescriptionTextView);
			this.GtkAlignment5.Add (this.GtkScrolledWindow1);
			this.frame4.Add (this.GtkAlignment5);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("Description:");
			this.frame4.LabelWidget = this.GtkLabel5;
			this.vbox3.Add (this.frame4);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame4]));
			w21.Position = 5;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame5 = new global::Gtk.Frame ();
			this.frame5.Name = "frame5";
			this.frame5.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame5.Gtk.Container+ContainerChild
			this.GtkAlignment6 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment6.Name = "GtkAlignment6";
			this.GtkAlignment6.LeftPadding = ((uint)(12));
			// Container child GtkAlignment6.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.RatingEntry = new global::Gtk.Entry ();
			this.RatingEntry.CanFocus = true;
			this.RatingEntry.Name = "RatingEntry";
			this.RatingEntry.IsEditable = true;
			this.RatingEntry.InvisibleChar = '●';
			this.vbox6.Add (this.RatingEntry);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.RatingEntry]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Sensitive = false;
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("ESRB, PEGI, etc.");
			this.vbox6.Add (this.label6);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.label6]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			this.GtkAlignment6.Add (this.vbox6);
			this.frame5.Add (this.GtkAlignment6);
			this.GtkLabel6 = new global::Gtk.Label ();
			this.GtkLabel6.Name = "GtkLabel6";
			this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString ("Rating:");
			this.frame5.LabelWidget = this.GtkLabel6;
			this.vbox3.Add (this.frame5);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame5]));
			w26.Position = 6;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame6 = new global::Gtk.Frame ();
			this.frame6.Name = "frame6";
			this.frame6.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame6.Gtk.Container+ContainerChild
			this.GtkAlignment7 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment7.Name = "GtkAlignment7";
			this.GtkAlignment7.LeftPadding = ((uint)(12));
			// Container child GtkAlignment7.Gtk.Container+ContainerChild
			this.DeveloperEntry = new global::Gtk.Entry ();
			this.DeveloperEntry.CanFocus = true;
			this.DeveloperEntry.Name = "DeveloperEntry";
			this.DeveloperEntry.IsEditable = true;
			this.DeveloperEntry.InvisibleChar = '●';
			this.GtkAlignment7.Add (this.DeveloperEntry);
			this.frame6.Add (this.GtkAlignment7);
			this.GtkLabel7 = new global::Gtk.Label ();
			this.GtkLabel7.Name = "GtkLabel7";
			this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("Developer:");
			this.frame6.LabelWidget = this.GtkLabel7;
			this.vbox3.Add (this.frame6);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame6]));
			w29.Position = 7;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame7 = new global::Gtk.Frame ();
			this.frame7.Name = "frame7";
			this.frame7.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame7.Gtk.Container+ContainerChild
			this.GtkAlignment8 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment8.Name = "GtkAlignment8";
			this.GtkAlignment8.LeftPadding = ((uint)(12));
			// Container child GtkAlignment8.Gtk.Container+ContainerChild
			this.PublisherEntry = new global::Gtk.Entry ();
			this.PublisherEntry.CanFocus = true;
			this.PublisherEntry.Name = "PublisherEntry";
			this.PublisherEntry.IsEditable = true;
			this.PublisherEntry.InvisibleChar = '●';
			this.GtkAlignment8.Add (this.PublisherEntry);
			this.frame7.Add (this.GtkAlignment8);
			this.GtkLabel8 = new global::Gtk.Label ();
			this.GtkLabel8.Name = "GtkLabel8";
			this.GtkLabel8.LabelProp = global::Mono.Unix.Catalog.GetString ("Publisher:");
			this.frame7.LabelWidget = this.GtkLabel8;
			this.vbox3.Add (this.frame7);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame7]));
			w32.Position = 8;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame8 = new global::Gtk.Frame ();
			this.frame8.Name = "frame8";
			this.frame8.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame8.Gtk.Container+ContainerChild
			this.GtkAlignment9 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment9.Name = "GtkAlignment9";
			this.GtkAlignment9.LeftPadding = ((uint)(12));
			// Container child GtkAlignment9.Gtk.Container+ContainerChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.BannerArtPathEntry = new global::Gtk.Entry ();
			this.BannerArtPathEntry.Sensitive = false;
			this.BannerArtPathEntry.CanFocus = true;
			this.BannerArtPathEntry.Name = "BannerArtPathEntry";
			this.BannerArtPathEntry.IsEditable = true;
			this.BannerArtPathEntry.InvisibleChar = '●';
			this.hbox4.Add (this.BannerArtPathEntry);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.BannerArtPathEntry]));
			w33.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.button105 = new global::Gtk.Button ();
			this.button105.CanFocus = true;
			this.button105.Name = "button105";
			this.button105.Label = global::Mono.Unix.Catalog.GetString ("Browse...");
			global::Gtk.Image w34 = new global::Gtk.Image ();
			w34.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-directory", global::Gtk.IconSize.Button);
			this.button105.Image = w34;
			this.hbox4.Add (this.button105);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.button105]));
			w35.Position = 1;
			w35.Expand = false;
			w35.Fill = false;
			this.vbox7.Add (this.hbox4);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.hbox4]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.BannerPreview = new global::Gtk.Image ();
			this.BannerPreview.Name = "BannerPreview";
			this.vbox7.Add (this.BannerPreview);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.BannerPreview]));
			w37.Position = 1;
			w37.Expand = false;
			w37.Fill = false;
			this.GtkAlignment9.Add (this.vbox7);
			this.frame8.Add (this.GtkAlignment9);
			this.GtkLabel10 = new global::Gtk.Label ();
			this.GtkLabel10.Name = "GtkLabel10";
			this.GtkLabel10.LabelProp = global::Mono.Unix.Catalog.GetString ("Banner Art:");
			this.frame8.LabelWidget = this.GtkLabel10;
			this.vbox3.Add (this.frame8);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame8]));
			w40.Position = 9;
			w40.Expand = false;
			w40.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame9 = new global::Gtk.Frame ();
			this.frame9.Name = "frame9";
			this.frame9.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame9.Gtk.Container+ContainerChild
			this.GtkAlignment11 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment11.Name = "GtkAlignment11";
			this.GtkAlignment11.LeftPadding = ((uint)(12));
			// Container child GtkAlignment11.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox ();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BoxArtPathEntry = new global::Gtk.Entry ();
			this.BoxArtPathEntry.Sensitive = false;
			this.BoxArtPathEntry.CanFocus = true;
			this.BoxArtPathEntry.Name = "BoxArtPathEntry";
			this.BoxArtPathEntry.IsEditable = true;
			this.BoxArtPathEntry.InvisibleChar = '●';
			this.hbox5.Add (this.BoxArtPathEntry);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.BoxArtPathEntry]));
			w41.Position = 0;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BoxArtButton = new global::Gtk.Button ();
			this.BoxArtButton.CanFocus = true;
			this.BoxArtButton.Name = "BoxArtButton";
			this.BoxArtButton.Label = global::Mono.Unix.Catalog.GetString ("Browse...");
			global::Gtk.Image w42 = new global::Gtk.Image ();
			w42.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-directory", global::Gtk.IconSize.Button);
			this.BoxArtButton.Image = w42;
			this.hbox5.Add (this.BoxArtButton);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.BoxArtButton]));
			w43.Position = 1;
			w43.Expand = false;
			w43.Fill = false;
			this.vbox8.Add (this.hbox5);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.hbox5]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.BoxArtPreview = new global::Gtk.Image ();
			this.BoxArtPreview.Name = "BoxArtPreview";
			this.vbox8.Add (this.BoxArtPreview);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox8 [this.BoxArtPreview]));
			w45.Position = 1;
			w45.Expand = false;
			w45.Fill = false;
			this.GtkAlignment11.Add (this.vbox8);
			this.frame9.Add (this.GtkAlignment11);
			this.GtkLabel12 = new global::Gtk.Label ();
			this.GtkLabel12.Name = "GtkLabel12";
			this.GtkLabel12.LabelProp = global::Mono.Unix.Catalog.GetString ("Box Art:");
			this.GtkLabel12.UseMarkup = true;
			this.frame9.LabelWidget = this.GtkLabel12;
			this.vbox3.Add (this.frame9);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame9]));
			w48.Position = 10;
			w48.Expand = false;
			w48.Fill = false;
			w2.Add (this.vbox3);
			this.GtkScrolledWindow.Add (w2);
			w1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(w1 [this.GtkScrolledWindow]));
			w51.Position = 0;
			// Internal child EMUlsifier.GameDialog.ActionArea
			global::Gtk.HButtonBox w52 = this.ActionArea;
			w52.Name = "dialog1_ActionArea";
			w52.Spacing = 10;
			w52.BorderWidth = ((uint)(5));
			w52.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.Sensitive = false;
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w53 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w52 [this.buttonOk]));
			w53.Expand = false;
			w53.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w54 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w52 [this.buttonCancel]));
			w54.Position = 1;
			w54.Expand = false;
			w54.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 469;
			this.DefaultHeight = 495;
			this.Show ();
			this.SizeAllocated += new global::Gtk.SizeAllocatedHandler (this.GameDialogOnSizeAllocate);
			this.GameTitleEntry.Changed += new global::System.EventHandler (this.GameTitleEntryOnChange);
			this.BannerArtPathEntry.Changed += new global::System.EventHandler (this.BannerArtPathOnchange);
			this.button105.Clicked += new global::System.EventHandler (this.BannerArtBrowserOnClick);
			this.BoxArtPathEntry.Changed += new global::System.EventHandler (this.BoxArtPathOnChange);
		}
	}
}
