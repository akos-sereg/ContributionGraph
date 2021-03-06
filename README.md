[![Version](https://img.shields.io/nuget/v/ContributionGraph.svg)](https://www.nuget.org/packages/ContributionGraph)

Contribution Graph
=================

Calendar based heat map for .NET, similar to GitHub's contribution graph.

In order to install this component, right click on your project in Visual Studio, select "Manage NuGet Packages...", and search for "ContributionGraph" in Online packages.

# Usage

```c#
ContributionList data = new ContributionList { 
    new ContributionItem { Date = DateTime.Parse("2014-11-02"), ContributionCount = 1, Subject = "A" },
    new ContributionItem { Date = DateTime.Parse("2014-11-05"), ContributionCount = 3, Subject = "B" },
    new ContributionItem { Date = DateTime.Parse("2014-11-06"), ContributionCount = 6, Subject = "C" },
    new ContributionItem { Date = DateTime.Parse("2014-11-09"), ContributionCount = 11, Subject = "D" },
    new ContributionItem { Date = DateTime.Parse("2014-11-11"), ContributionCount = 16, Subject = "DayPanel.cs" } 
};

this.calendarView1.DataSource = data;
```

Screenshot of above example:

![Contribution Graph](https://raw.githubusercontent.com/akos-sereg/ContributionGraph/master/ContributionGraph/Docs/Screenshot.png "Screenshot")

... or you can build ContributionList by adding Commit instances. These instances will be aggregated to ContributionItem instances in the background:

```c#
ContributionList data = new ContributionList();

data.Add(new Commit { Date = Date = DateTime.Parse("2014-11-02"), Author = "akos-sereg", Title = "Commit message #1" });
data.Add(new Commit { Date = Date = DateTime.Parse("2014-11-02"), Author = "akos-sereg", Title = "Commit message #2" });
data.Add(new Commit { Date = Date = DateTime.Parse("2014-11-06"), Author = "akos-sereg", Title = "Commit message #3" });

this.calendarView1.DataSource = data;
```

# Configuration

```c#
// If you want to use a different color-schema for rendering contribution cells (green ones by 
// default), you can implement IColorProvider interface and tell Calendar View component to use 
// that.
this.calendarView1.ColorProvider = new CustomColorProvider();

// You can also set the color of the cells where there was no contribution (gray by default).
this.calendarView1.DefaultColor = Color.Gray;
this.calendarView1.DefaultColorHover = Color.LightGray;

// By default, Calendar View displays 53 weeks. If you change this value, the control's width will 
// be changed accordingly.
this.calendarView1.DisplayedWeeks = 10;

// Cell sizes are 12x12 pixels by default, you can make cells bigger/smaller by changing CellSize property
this.calendarView1.CellSize = 8;

// Calendar View displays weeks up till current date, by default. If you want to display contribution 
// with different date range, you might want to modify this property.
this.calendarView1.EndDate = DateTime.Now;
```

# Events

```c#
// OnContributionSelected event is fired when user clicks on a green or gray cell
this.calendarView1.OnContributionSelected += (contrib) => { MessageBox.Show(contrib.Subject); };
```

