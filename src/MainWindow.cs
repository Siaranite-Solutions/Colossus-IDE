using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colossus_IDE
{
	public partial class MainWindow : Form
	{
		private int TabCount = 0;
		public bool saved = false;
		private RichTextBox GetCurrentDocument
		{
			get
			{
				return (RichTextBox)tabControl1.SelectedTab.Controls["Body"];
			}
		}
		public MainWindow()
		{
			InitializeComponent();
		}

		#region Methods 
		#region Tabs 
		private void AddTab()
		{
			RichTextBox Body = new RichTextBox();
			Body.Name = "Body";
			
			Body.Dock = DockStyle.Fill;
			Body.ContextMenuStrip = contextMenuStrip1;
			TabPage NewPage = new TabPage();
			TabCount += 1;
			string DocumentText = "Document " + TabCount;
			NewPage.Name = DocumentText;
			NewPage.Text = DocumentText;
			NewPage.Controls.Add(Body);
			tabControl1.TabPages.Add(NewPage);
		}
		private void RemoveTab()
		{
			if (tabControl1.TabPages.Count != 1)
			{
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
			}
			else
			{
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
				AddTab();
			}
		}
		private void RemoveAllTabs()
		{
			foreach (TabPage page in tabControl1.TabPages)
			{
				tabControl1.TabPages.Remove(page);
			}
			AddTab();
		}
		private void RemoveAllTabsButThis()
		{
			foreach (TabPage page in tabControl1.TabPages)
			{
				if (page.Name != tabControl1.SelectedTab.Name)
				{
					tabControl1.TabPages.Remove(page);
				}
			}
		}
		#endregion

		#region SaveAndOpen 
		private void Save()
		{
			saveFileDialog.FileName = tabControl1.SelectedTab.Name;
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			saveFileDialog.Filter = "Text Files|*.txt|C# Files|*.cs|Visual Basic Files|*.vb|AIL VM Files|*.avm|All Files|*.*";
			saveFileDialog.Title = "Save";
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (saveFileDialog.FileName.Length > 0)
				{
					GetCurrentDocument.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
				}
			}
		}
		private void SaveAs()
		{
			saveFileDialog.FileName = tabControl1.SelectedTab.Name;
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			saveFileDialog.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*";
			saveFileDialog.Title = "Save As";
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (saveFileDialog.FileName.Length > 0)
				{
					GetCurrentDocument.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
				}
			}

		}
		private void Open()
		{
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			openFileDialog.Filter = "Text Files|*.txt|VB Files|*.vb|C# Files|*.cs|All Files|*.*";
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{ if (openFileDialog.FileName.Length > 9)
				{
					GetCurrentDocument.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
				}
			}		
		}
		#endregion

		#endregion

		private void newToolStripButton1_Click(object sender, EventArgs e)
		{
			AddTab();
		}

		private void saveToolStripButton1_Click(object sender, EventArgs e)
		{
			Save();
		}
		#region CurrentDocumentMethods
		private void Cut()
		{
			GetCurrentDocument.Cut();
		}
		private void Copy()
		{
			GetCurrentDocument.Copy();
		}
		private void Paste()
		{
			GetCurrentDocument.Paste();
		}
		private void Undo()
		{
			GetCurrentDocument.Undo();
		}
		private void Redo()
		{
			GetCurrentDocument.Redo();
		}
		private void SelectAll()
		{
			GetCurrentDocument.SelectAll();
		}
		#endregion
		private void cutToolStripButton1_Click(object sender, EventArgs e)
		{
			Cut();
		}

		private void copyToolStripButton1_Click(object sender, EventArgs e)
		{
			Copy();
		}

		private void pasteToolStripButton1_Click(object sender, EventArgs e)
		{
			Paste();
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			AddTab();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void openToolStripButton1_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTab();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveAs();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Undo();
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Redo();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Paste();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectAll();
		}

		private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About aboutbox = new About();
			aboutbox.ShowDialog();
		}

		private void LeftToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			Cut();
		}

		private void copyToolStripButton_Click(object sender, EventArgs e)
		{
			Copy();
		}

		private void pasteToolStripButton_Click(object sender, EventArgs e)
		{
			Paste();
		}

		private void printToolStripButton_Click(object sender, EventArgs e)
		{
			AIL_VM.Debug(GetCurrentDocument.Lines);
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			AddTab();
		}
		private void MainWindow_FormClosing(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}