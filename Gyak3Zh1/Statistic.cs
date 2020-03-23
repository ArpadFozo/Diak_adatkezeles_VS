using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak3Zh1
{
    class Statistic
    {
        List<Worker> workers;
        List<Project> projects;
        IQueryable<connector> connectors;
        public Statistic(List<Worker> workers, List<Project> projects, IQueryable<connector> connectors)
        {
            this.workers = workers;
            this.projects = projects;
            this.connectors = connectors;
        }

        public void Salary()
        {
            var query = from x in workers
                        where x.HireDate != null
                        orderby x.DefaultSalary descending
                        select new
                        {
                            Name = x.WorkerName,
                            Salary = x.DefaultSalary
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " | " + item.Salary);
            }
        }

        public void JobAvgSalary()
        {
            var query = from x in workers
                        group x by x.Job into g
                        orderby g.Average(t => t.DefaultSalary) descending
                        select new
                        {
                            Name = g.Key,
                            Avg = g.Average(t => t.DefaultSalary)
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " | " + item.Avg);
            }
                        
        }

        public void Varkonyi()
        {
            var query = from x in workers
                        join y in projects on x.WorkerID equals y.ProjectManager
                        where x.WorkerName == "Várkonyi Tamás"
                        group y by y.Costumer into g
                        select new
                        {
                            Costumer = g.Key,
                            Avg = g.Average(t => t.Cost)
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.Costumer + " | " + item.Avg);
            }
        }

        public void NIKHOK()
        {
            var query = from x in workers
                        join y in connectors on x.WorkerID equals y.workerId
                        join z in projects on y.projectId equals z.ProjectID
                        where z.Costumer == "NIK HÖK"
                        group x by x.Diploma into g
                        select new
                        {
                            None = g.Count(t => t.Diploma.ToString() == "none"),
                            BSc = g.Count(t => t.Diploma.ToString() == "BSc"),
                            MSc = g.Count(t => t.Diploma.ToString() == "MSc")
                        };
            foreach (var item in query.Distinct())
            {
                Console.WriteLine("None: " + item.None + "\nBSc: " + item.BSc + "\nMSc: " + item.MSc);
            }
        }
    }
}
