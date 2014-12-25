Contribution Graph
=================

Calendar-based graph for .NET, similar that is used by Github to indicate weekly contribution.

# Usage

```c#
ContributionList data = new ContributionList { 
    new ContributionItem { 
        Date = DateTime.Parse("2014-11-02"), 
        ContributionCount = 1, 
        Subject = "App.config" },

    new ContributionItem { 
        Date = DateTime.Parse("2014-11-05"), 
        ContributionCount = 3, 
        Subject = "Web.config" },

    new ContributionItem { 
        Date = DateTime.Parse("2014-11-06"), 
        ContributionCount = 6, 
        Subject = "ContributionItem.cs" },

    new ContributionItem { 
        Date = DateTime.Parse("2014-11-09"), 
        ContributionCount = 11, 
        Subject = "IColorProvider.cs" },

    new ContributionItem { 
        Date = DateTime.Parse("2014-11-11"), 
        ContributionCount = 16, 
        Subject = "DayPanel.cs" } 
};

this.calendarView1.DataSource = data;
```

Screenshot of above example:

![Contribution Graph](https://raw.githubusercontent.com/akos-sereg/ContributionGraph/master/ContributionGraph/Docs/Screenshot.png "Screenshot")
