ContributionGraph
=================

# Usage

```c#
ContributionList data = new ContributionList { 
    new ContributionItem { Date = DateTime.Parse("2014-11-02"), ContributionCount = 0 },
    new ContributionItem { Date = DateTime.Parse("2014-11-05"), ContributionCount = 3 },
    new ContributionItem { Date = DateTime.Parse("2014-11-06"), ContributionCount = 6 },
    new ContributionItem { Date = DateTime.Parse("2014-11-09"), ContributionCount = 11 },
    new ContributionItem { Date = DateTime.Parse("2014-11-11"), ContributionCount = 16 } 
};

this.calendarView1.DataSource = data;
```
