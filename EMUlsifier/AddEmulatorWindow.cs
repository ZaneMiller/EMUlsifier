using System;
using Gtk;
using EMUlsifier;

namespace EMUlsifier
{
	public partial class AddEmulatorWindow : Gtk.Window
	{
		public AddEmulatorWindow () : 
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			FillSystemCombo ();
			AddEmulatorButton.Sensitive = TestValidForm();
		}

		/// <summary>
		/// Fills the system combo box and selects the first item.
		/// </summary>
		protected void FillSystemCombo()
		{
			//Fill in the values
			foreach (string sys in Core.SystemTypes.Systems)
				SystemTypeCombo.AppendText(sys);
			//Set the first value as selected
			TreeIter iter;
			SystemTypeCombo.Model.GetIterFirst (out iter);
			SystemTypeCombo.SetActiveIter (iter);
		}

		/// <summary>
		/// Called when the browse button next to the emulator field is clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void EmulatorPathOnClick (object sender, EventArgs e)
		{
			//Open the dialog
			FileChooserDialog fc = new FileChooserDialog ("Choose the emulator executable",
				                       this,
				                       FileChooserAction.Open,
				                       "Select", ResponseType.Accept,
				                       "Cancel", ResponseType.Cancel);
			//If accepted, set the input
			if (fc.Run () == (int)ResponseType.Accept)
				EmulatorPathEntry.Text = fc.Filename;
			//Close the dialog
			fc.Destroy ();
			//Check the form state
			AddEmulatorButton.Sensitive = TestValidForm ();
		}

		/// <summary>
		/// Called when the browse button next to the rom folder field is clicked
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void RomPathButtonOnClick (object sender, EventArgs e)
		{
			//Open the dialog
			FileChooserDialog fc = new FileChooserDialog ("Choose the ROM folder",
				this,
				FileChooserAction.SelectFolder,
				"Select", ResponseType.Accept,
				"Cancel", ResponseType.Cancel);
			//If accepted, set the input
			if (fc.Run () == (int)ResponseType.Accept)
				RomPathEntry.Text = fc.Filename;
			//Close the dialog
			fc.Destroy ();
			//Check the form state
			AddEmulatorButton.Sensitive = TestValidForm ();
		}

		/// <summary>
		/// Called when any of the inputs for adding an emulator lose focus.
		/// Checks to see if the form is valid, if so enables the button, if not disables.
		/// </summary>
		/// <param name="o">O.</param>
		/// <param name="args">Arguments.</param>
		protected void AddEmuEntryOnBlur (object o, FocusOutEventArgs args)
		{
			AddEmulatorButton.Sensitive = TestValidForm ();
		}

		/// <summary>
		/// Called when the input for any of the entry fields changes.
		/// Checks to see if the form is valid and sets button state.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void AddEmuEntryOnChange (object sender, EventArgs e)
		{
			AddEmulatorButton.Sensitive = TestValidForm ();
		}

		/// <summary>
		/// Tests to see if the form is valid (I.E. all inputs are filled)
		/// </summary>
		/// <returns><c>true</c>, if valid form was tested, <c>false</c> otherwise.</returns>
		protected bool TestValidForm()
		{
			//Simply checks to make sure there is values in every field
			return (!String.IsNullOrWhiteSpace(EmulatorNameEntry.Text)
					&& !String.IsNullOrWhiteSpace(EmulatorPathEntry.Text)
				&& !String.IsNullOrWhiteSpace(RomPathEntry.Text)
				&& !String.IsNullOrWhiteSpace(EmulatorLaunchArgsEntry.Text));
		}

		/// <summary>
		/// Called when the cancel button is clicked. Simply closes the window.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void AddEmuCancelonClick (object sender, EventArgs e)
		{
			//Close the window
			this.Destroy ();
		}

		/// <summary>
		/// Called when the add button is clicked.
		/// If the form is valid the data is saved to a new instance of the model and the list is updated.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void AddEmulatorButtonOnClick (object sender, EventArgs e)
		{
			if (!TestValidForm())
				return;

			//Create the new instance
			Emulator emu = new Emulator () {
				name = EmulatorNameEntry.Text,
				path = EmulatorPathEntry.Text,
				args = EmulatorLaunchArgsEntry.Text,
				system = SystemTypeCombo.ActiveText,
				romFolder = RomPathEntry.Text
			};
			//Add it the the list of references
			EmulatorController.emulators.Add (emu);
			//Update the view
			MainClass.win.UpdateEmulatorTree ();
			//Close the window
			this.Destroy ();
		}
	}
}

