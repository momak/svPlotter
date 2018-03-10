using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HierarhyPlot
{
    public class StavkaVrska
    {
        public string Stavka { get; set; }
        public string PodIzvor { get; set; }
        public int Kod { get; set; }
        public int Znak { get; set; }
        public bool isProccesed { get; set; }

        public List<StavkaVrska> GetList(string filePath)
        {
            List<StavkaVrska> list  = new List<StavkaVrska>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode root = doc.SelectSingleNode("//Vrski");
            XmlNodeList nodeList = root.SelectNodes("Vrska");

            foreach (XmlNode n in nodeList)
            {
                StavkaVrska _sv = new StavkaVrska
                {
                    Stavka = n.SelectSingleNode("Stavka").InnerText.Trim(),
                    PodIzvor = n.SelectSingleNode("podIzvor").InnerText.Trim(),
                    Znak = 1,
                    Kod = Convert.ToInt32(n.SelectSingleNode("Kod").InnerText.Trim()),
                    isProccesed = false
                    
                };

                list.Add(_sv);
            }
            return list;
        }
    }
}
