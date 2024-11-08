using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    [Table(Name = "jobs")]
    public class Jobs
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public Jobs() { }

        public Jobs(string jobTitle, decimal minSalary, decimal maxSalary) {
            JobTitle = jobTitle;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        public Jobs(int jobId, string jobTitle, decimal minSalary, decimal maxSalary)
            : this(jobTitle, minSalary, maxSalary) {

            JobId = jobId;
        }

        public override string ToString()
        {
            return $"Id: {JobId}\n" +
                $"Title: {JobTitle}\n" +
                $"MinSal: {MinSalary}\n" +
                $"MaxSal: {MaxSalary}";
        }
    }
}
