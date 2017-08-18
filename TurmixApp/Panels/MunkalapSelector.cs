using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurmixLog
{
	public partial class MunkalapSelector : Form
	{

		private List<WorkData> munkaLista = new List<WorkData>();
		private Color[] napszakColors = new Color[] { Color.FromArgb(252, 127, 113), Color.FromArgb(2, 219, 219), Color.Blue };

		public List<WorkData> MunkaLista
		{
			get { return munkaLista; }
		}

		public MunkalapSelector(List<Auto> autok, Repository repo)
		{

			InitializeComponent();

			autok.Sort(new Comparison<Auto>(Auto.CompareByKapacitas));

			TreeNode node, tn;

			try
			{

				foreach (Auto a in autok)
				{
					node = lista.Nodes.Add(a.Info);

					for (int nsz = 0; nsz < 3; nsz++)
					{
						foreach (WorkData ma in a.OsszesMunkalap(nsz))
						{
							tn = node.Nodes.Add(ma.GetInfo(true, true, false, true));
							tn.BackColor = napszakColors[ma.Napszak - 1];
							tn.ForeColor = ma.Napszak > 2 ? Color.White : Color.Black;
							tn.Tag = ma;
						}
					}
				}
			}
			catch (Exception ex)
			{

			}
		}

		private void MunkalapSelector_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach (TreeNode t in lista.Nodes)
			{
				foreach (TreeNode ch in t.Nodes)
				{
					if (ch.Checked)
						munkaLista.Add((WorkData)ch.Tag);
				}

			}
		}

		private void allbtn_Click(object sender, EventArgs e)
		{
			foreach (TreeNode t in lista.Nodes)
			{
				t.Checked = true;
			}
		}

		private void nonebtn_Click(object sender, EventArgs e)
		{
			foreach (TreeNode t in lista.Nodes)
			{
				t.Checked = false;
			}
		}

		private void lista_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent == null)
			{
				foreach (TreeNode ch in e.Node.Nodes)
				{
					ch.Checked = e.Node.Checked;
				}
				if (e.Node.Checked)
					e.Node.Expand();
				else
					e.Node.Collapse();
			}
		}
	}
}
