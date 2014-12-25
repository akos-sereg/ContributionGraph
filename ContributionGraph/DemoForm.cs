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
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();

            ContributionList data = new ContributionList { 
                new ContributionItem { Date = DateTime.Parse("2014-11-02"), ContributionCount = 1 },
                new ContributionItem { Date = DateTime.Parse("2014-11-05"), ContributionCount = 3 },
                new ContributionItem { Date = DateTime.Parse("2014-11-06"), ContributionCount = 6 },
                new ContributionItem { Date = DateTime.Parse("2014-11-09"), ContributionCount = 11 },
                new ContributionItem { Date = DateTime.Parse("2014-11-11"), ContributionCount = 16 } 
            };

            this.calendarView1.DataSource = data;
        }
    }
}
