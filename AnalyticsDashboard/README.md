# Analytics Dashboard - Demo Project 3

A real-time analytics dashboard built with Angular and Chart.js to visualize key business metrics.

## 📊 Features

- **4 KPI Cards** displaying:
  - Total Revenue ($124,500, +12.5%)
  - Active Users (8,542, +8.3%)
  - Conversion Rate (3.2%, -0.5%)
  - Average Session Duration (4.5 hrs, +2.1%)

- **Revenue Chart** (Line chart) - Shows monthly revenue trends
- **User Growth Chart** (Bar chart) - Displays user acquisition over time
- **Activity Feed** - Real-time user activity log

## 🚀 Getting Started

```bash
cd MoFiles/Portfolio/AnalyticsDashboard

# Install dependencies
npm install

# Run dev server
ng serve

# Open browser
http://localhost:4200
```

## 📁 Project Structure

```
src/app/
├── components/
│   ├── kpi-card/           # KPI card component
│   ├── chart-container/    # Chart wrapper component
│   └── activity-feed/      # Activity feed component
├── app.component.ts        # Main component with Chart.js initialization
└── app.component.html     # Dashboard layout template
```

## 🎨 Design Highlights

- Clean, modern UI with FontAwesome icons
- Color-coded indicators (green for growth, red for decline)
- Responsive layout with Bootstrap 5
- Smooth Chart.js animations

## 🔧 Technical Stack

- **Angular 17+** - Framework
- **Chart.js** - Data visualization
- **Bootstrap 5** - UI framework
- **FontAwesome** - Icons

---

*Part of a series: [Portfolio Site](#), [Angular Dashboard](#), [Data Visualization Dashboard](#)*
