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
        List<String> stavkiList = new List<String>();
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
            svList.Clear();
            stavkiList.Clear();
            tvVrski.Nodes.Clear();

            StavkaVrska _sv = new StavkaVrska();
            svList = _sv.GetList(txtFilePath.Text.Trim());
            GetStavki();


            //string s = "L8";
            //tvVrski.Nodes.Add(ChildNodes(s));
          //return;
            
            tvVrski.Nodes.Clear();

            foreach (string stavka in stavkiList)
            {
                TreeNode pNode = new TreeNode();
                pNode.Name = stavka;
                pNode.Text = stavka;



                //pNode.Nodes.Add(ChildNodes(stavkaVrska.Stavka));

                //tvVrski.Nodes.Add(pNode);

                if (!tvVrski.Nodes.Contains(pNode))
                {
                    tvVrski.Nodes.Add(ChildNodes(stavka));
                }
                
                //return;
            }


            

            return;

            foreach (StavkaVrska stavkaVrska in svList)
            {
                if (!stavkaVrska.isProccesed)
                {
                    TreeNode parentNode = new TreeNode();
                    parentNode.Name = stavkaVrska.Stavka;
                    parentNode.Text = stavkaVrska.Stavka;
                    parentNode.Tag = stavkaVrska.PodIzvor;

                    stavkaVrska.isProccesed = true;

                    parentNode.Nodes.Add(ChildNodes(stavkaVrska.PodIzvor));

                    tvVrski.Nodes.Add(parentNode);
                    //tvVrski.Nodes.Add(ChildNodes(stavkaVrska.PodIzvor));
                }
            }
        }

        private TreeNode ChildNodes(string podIvor)
        {
            TreeNode node = new TreeNode();
            foreach (StavkaVrska stavkaVrska in svList)
            {
                if ((stavkaVrska.Stavka == podIvor) && (!stavkaVrska.isProccesed) && (stavkaVrska.Kod != 1))
                {
                    node.Name = stavkaVrska.Stavka;
                    node.Text = stavkaVrska.Stavka;
                    //node.Tag = stavkaVrska.PodIzvor;
                    node.Nodes.Add(ChildNodes(stavkaVrska.PodIzvor));
                    stavkaVrska.isProccesed = true;
                }
                else if ((stavkaVrska.Kod == 1) && (stavkaVrska.Stavka == podIvor))
                {
                    node.Name = stavkaVrska.Stavka;
                    node.Text = stavkaVrska.Stavka;
                    //node.Tag = stavkaVrska.PodIzvor;
                    node.BackColor = Color.Red;
                    stavkaVrska.isProccesed = true;

                    return node;
                }
            }
            return node;
        }

        private void GetStavki()
        {
            foreach (StavkaVrska stavkaVrska in svList)
            {
                var b = false;
                foreach (string stavka in stavkiList)
                {
                    if (stavka == stavkaVrska.Stavka)
                    {
                        b = true;
                    }
                }

                if (!b)
                    stavkiList.Add(stavkaVrska.Stavka);
            }
        }
    }
}
