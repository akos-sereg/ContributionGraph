using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContributionGraph.Model;

namespace ContributionGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ContributionList data = new ContributionList { 
                new ContributionItem { Date = DateTime.Parse("2014-11-02"), Title = "Hello World", ContributionCount = 0 },
                new ContributionItem { Date = DateTime.Parse("2014-11-05"), Title = "Hello World", ContributionCount = 3 },
                new ContributionItem { Date = DateTime.Parse("2014-11-06"), Title = "Hello World", ContributionCount = 6 },
                new ContributionItem { Date = DateTime.Parse("2014-11-09"), Title = "Hello World", ContributionCount = 11 },
                new ContributionItem { Date = DateTime.Parse("2014-11-11"), Title = "Hello World", ContributionCount = 16 } 
            };

            this.calendarView1.DataSource = data;
        }
    }
}
