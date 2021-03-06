
// This file has been generated by the GUI designer. Do not modify.
namespace EMUlsifier
{
	public partial class GameSearchResultDialog
	{
		private global::Gtk.HBox hbox4;
		private global::Gtk.Image image48;
		private global::Gtk.Label label5;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.Frame frame9;
		private global::Gtk.Alignment GtkAlignment2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView GameSearchResultTreeView;
		private global::Gtk.Label GtkLabel2;
		private global::Gtk.Button GameSearchResultOkButton;
		private global::Gtk.Button buttonCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget EMUlsifier.GameSearchResultDialog
			this.Name = "EMUlsifier.GameSearchResultDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("EMUlsifier - Search Results");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.BorderWidth = ((uint)(6));
			// Internal child EMUlsifier.GameSearchResultDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.image48 = new global::Gtk.Image ();
			this.image48.Name = "image48";
			this.image48.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("EMUlsifier.icons.1388384270_search.png");
			this.hbox4.Add (this.image48);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.image48]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b><big>Search Results</big></b>");
			this.label5.UseMarkup = true;
			this.hbox4.Add (this.label5);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label5]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			w1.Add (this.hbox4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox4]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			w1.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(w1 [this.hseparator2]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			w5.Padding = ((uint)(6));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.frame9 = new global::Gtk.Frame ();
			this.frame9.Name = "frame9";
			this.frame9.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame9.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.GameSearchResultTreeView = new global::Gtk.TreeView ();
			this.GameSearchResultTreeView.CanFocus = true;
			this.GameSearchResultTreeView.Name = "GameSearchResultTreeView";
			this.GameSearchResultTreeView.EnableSearch = false;
			this.GameSearchResultTreeView.HeadersVisible = false;
			this.GtkScrolledWindow.Add (this.GameSearchResultTreeView);
			this.GtkAlignment2.Add (this.GtkScrolledWindow);
			this.frame9.Add (this.GtkAlignment2);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("Select A Game:");
			this.frame9.LabelWidget = this.GtkLabel2;
			w1.Add (this.frame9);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(w1 [this.frame9]));
			w9.Position = 2;
			// Internal child EMUlsifier.GameSearchResultDialog.ActionArea
			global::Gtk.HButtonBox w10 = this.ActionArea;
			w10.Name = "dialog1_ActionArea";
			w10.Spacing = 10;
			w10.BorderWidth = ((uint)(5));
			w10.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.GameSearchResultOkButton = new global::Gtk.Button ();
			this.GameSearchResultOkButton.Sensitive = false;
			this.GameSearchResultOkButton.CanDefault = true;
			this.GameSearchResultOkButton.CanFocus = true;
			this.GameSearchResultOkButton.Name = "GameSearchResultOkButton";
			this.GameSearchResultOkButton.UseStock = true;
			this.GameSearchResultOkButton.UseUnderline = true;
			this.GameSearchResultOkButton.Label = "gtk-ok";
			this.AddActionWidget (this.GameSearchResultOkButton, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w11 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w10 [this.GameSearchResultOkButton]));
			w11.Expand = false;
			w11.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w10 [this.buttonCancel]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 301;
			this.Show ();
			this.GameSearchResultTreeView.CursorChanged += new global::System.EventHandler (this.GameSearchResultOnCursorChange);
		}
	}
}
