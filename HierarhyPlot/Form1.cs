using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HierarhyPlot
{
    public partial class Form1 : Form
    {
        List<StavkaVrska> svList = new List<StavkaVrska>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFilePicker_Click(object sender, EventArgs e)
        {
            OpenFileDialog openXml = new OpenFileDialog();

            openXml.InitialDirectory = Environment.CurrentDirectory;
            openXml.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openXml.Title = "Choose xml file to plot";
            openXml.Multiselect = false;
            openXml.CheckPathExists = true;
            openXml.RestoreDirectory = true;

            if (openXml.ShowDialog() == DialogResult.OK)
            {
                if (openXml.CheckFileExists)
                    txtFilePath.Text = openXml.FileName;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            StavkaVrska _sv = new StavkaVrska();
            svList = _sv.GetList(txtFilePath.Text.Trim());

            tvVrski.Nodes.Clear();

            foreach (StavkaVrska stavkaVrska in svList)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Name = stavkaVrska.Stavka;
                parentNode.Text = stavkaVrska.Stavka;
                parentNode.Tag = stavkaVrska.PodIzvor;
                parentNode.Nodes.AddRange(ChildNodes(stavkaVrska.PodIzvor));

                tvVrski.Nodes.Add(parentNode);
            }

        }

        private TreeNode[] ChildNodes(string podIvor)
        {
            foreach (StavkaVrska stavkaVrska in svList)
            {
                if (stavkaVrska.Stavka == podIvor)
                {
                    TreeNode node = new TreeNode();
                    node.Name = stavkaVrska.Stavka;
                    node.Text = stavkaVrska.Stavka;
                    node.Tag = stavkaVrska.PodIzvor;
                    node.Nodes.AddRange(ChildNodes(stavkaVrska.PodIzvor));
                }
            }
        }
    }
}
