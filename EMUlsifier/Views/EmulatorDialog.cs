using System;
using Gtk;
using EMUlsifier;
using System.Linq;

namespace EMUlsifier
{
	public partial class EmulatorDialog : Gtk.Dialog
	{
		public Emulator emulator;

		public EmulatorDialog (Emulator emu) : 
		base ()
		{
			this.Build ();
			this.emulator = emu;
			FillInputs ();
			AddEmulatorButton.Sensitive = TestValidForm();
		}

		protected void FillInputs()
		{
			EmulatorNameEntry.Text = emulator.name;
			EmulatorPathEntry.Text = emulator.path;
			EmulatorLaunchArgsEntry.Text = emulator.args;
			RomPathEntry.Text = emulator.romFolder;
			RomMaskEntry.Text = string.Join (" ", emulator.romMasks);
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
			int row = Core.SystemTypes.Systems.IndexOf (emulator.system);
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
		protected void EmuEntryOnFocusOut (object o, FocusOutEventArgs args)
		{
			AddEmulatorButton.Sensitive = TestValidForm ();
		}

		/// <summary>
		/// Called when the input for any of the entry fields changes.
		/// Checks to see if the form is valid and sets button state.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected void EmuEntryOnChange (object sender, EventArgs e)
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

		public void UpdateEmulator()
		{
			emulator.name = EmulatorNameEntry.Text;
			emulator.path = EmulatorPathEntry.Text;
			emulator.args = EmulatorLaunchArgsEntry.Text;
			emulator.system = SystemTypeCombo.ActiveText;
			emulator.romFolder = RomPathEntry.Text;
			emulator.romMasks = RomMaskEntry.Text.Split (' ').ToList ();
		}

	}
}

