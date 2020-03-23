using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gyak3Zh1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = Worker.XMLLoad("worker.xml");
            List<Project> projects = Project.XMLLoad("project.xml");
            IQueryable<connector> connectors = new ConnectorEntities().connector;
            EmailCreate(workers);
            Statistic st = new Statistic(workers, projects, connectors);
            st.Salary();
            Console.WriteLine();
            st.JobAvgSalary();
            Console.WriteLine();
            st.Varkonyi();
            Console.WriteLine();
            st.NIKHOK();
            Console.ReadLine();
        }

        static void EmailCreate(List<Worker> list)
        {
            foreach (var item in list)
            {
                foreach (PropertyInfo prop in typeof(Worker).GetProperties())
                {
                    var temp = prop.GetCustomAttribute<EmailCreateAttribute>();
                    if (temp != null)
                    {
                        var email = item.WorkerName.Split(' ')[0].Substring(0, temp.First)
                            + temp.Sep
                            + item.WorkerName.Split(' ')[1].Substring(0, temp.Second)
                            + "@"
                            + temp.Domain;
                        item.WorkerMail = email;
                    }
                }
                
            }
        }
    }
}
