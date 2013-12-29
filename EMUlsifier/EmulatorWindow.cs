using System;
using Gtk;
using EMUlsifier;
using System.Linq;

namespace EMUlsifier
{
	public partial class EmulatorWindow : Gtk.Window
	{
		private Emulator emu;

		public EmulatorWindow (Emulator emu) : 
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			if(emu != null)
				this.emu = emu;
			FillInputs ();
			AddEmulatorButton.Sensitive = TestValidForm();
		}

		protected void FillInputs()
		{
			EmulatorNameEntry.Text = emu.name;
			EmulatorPathEntry.Text = emu.path;
			EmulatorLaunchArgsEntry.Text = emu.args;
			RomPathEntry.Text = emu.romFolder;
			RomMaskEntry.Text = string.Join (" ", emu.romMasks);
			FillSystemCombo ();
		}

		/// <summary>
		/// Fills the system combo box and selects the first item.
		/// </summary>
		protected void FillSystemCombo()
		{
			//Fill in the values
			foreach (string sys in Core.SystemTypes.Systems)
				SystemTypeCombo.AppendText(sys);
			//Find the correct value and select it
			TreeIter iter;
			int row = Core.SystemTypes.Systems.IndexOf (emu.system);
			SystemTypeCombo.Model.IterNthChild (out iter, row);
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
			//NOTE: The mask isn't required, so we ignore that field in our check
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
			UpdateEmulator ();
			//Add it the the list of references if need be
			if(!EmulatorController.emulators.Contains(emu))
				EmulatorController.emulators.Add (emu);
			//Update the view
			MainClass.win.UpdateEmulatorTree ();
			//Close the window
			this.Destroy ();
		}

		protected void UpdateEmulator()
		{
			emu.name = EmulatorNameEntry.Text;
			emu.path = EmulatorPathEntry.Text;
			emu.args = EmulatorLaunchArgsEntry.Text;
			emu.system = SystemTypeCombo.ActiveText;
			emu.romFolder = RomPathEntry.Text;
			emu.romMasks = RomMaskEntry.Text.Split (' ').ToList ();
		}
	}
}

