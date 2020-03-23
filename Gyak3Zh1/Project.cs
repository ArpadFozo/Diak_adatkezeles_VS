using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gyak3Zh1
{
    class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Costumer { get; set; }
        public int Cost { get; set; }
        public int ProjectManager { get; set; }

        public static List<Project> XMLLoad(string url)
        {
            List<Project> returnList = new List<Project>();
            XDocument xdoc = XDocument.Load(url);
            foreach (var item in xdoc.Descendants("project"))
            {
                var temp = new Project {
                    ProjectID = int.Parse(item.Element("projectid").Value),
                    ProjectName = item.Element("projectname").Value,
                    Costumer = item.Element("customer").Value,
                    Cost = int.Parse(item.Element("cost").Value),
                    ProjectManager = int.Parse(item.Element("projectmanager").Value)
                };
                returnList.Add(temp);
            }
            return returnList;
        }
    }
}
