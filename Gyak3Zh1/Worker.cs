using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gyak3Zh1
{
    enum Diploma { none, BSc, MSc}
    class Worker
    {
        public int WorkerID { get; set; }
        [EmailCreate(3, 3, ',', "vallalkozas.hu")]
        public string WorkerName { get; set; }
        public string WorkerMail { get; set; }
        public string Job { get; set; }
        public int DefaultSalary { get; set; }
        public DateTime HireDate { get; set; }
        public Diploma Diploma { get; set; }
        public static List<Worker> XMLLoad(string url)
        {
            List<Worker> returnList = new List<Worker>();
            XDocument xdoc = XDocument.Load(url);
            foreach (var item in xdoc.Descendants("worker"))
            {
                var temp = new Worker
                {
                    WorkerID = int.Parse(item.Element("workerid").Value),
                    WorkerName = item.Element("workername").Value,
                    Job = item.Element("job").Value,
                    DefaultSalary = int.Parse(item.Element("salary").Value),
                    HireDate = (item.Element("hiredate") == null) ? DateTime.MinValue : DateTime.Parse(item.Element("hiredate")?.Value),
                    Diploma = (item.Element("diploma") == null) ? Diploma.none : (Diploma)Enum.Parse(typeof(Diploma), item.Element("diploma")?.Value)

                };
                returnList.Add(temp);
            }
            return returnList;
        }
    }
}
