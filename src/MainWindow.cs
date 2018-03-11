using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnExitActionActivated (object sender, EventArgs e)
	{
		Application.Quit ();
	}
	protected void OnSaveActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}


	protected void OnSaveActionActivated (object sender, EventArgs e)
	{
		StreamWriter sw = new StreamWriter("Test.txt");
		sw.Write(textview1.Buffer.Text); //Write textview1 text to file
		textview1.Buffer.Text = "Saved to file !"; //Notify user
		sw.Close();
	}
}
