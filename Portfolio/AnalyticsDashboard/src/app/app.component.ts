import { Component, OnInit, OnDestroy } from '@angular/core';
import { Chart, registerables } from 'chart.js';

// Register all Chart.js components
Chart.register(...registerables);

interface KpiData {
  label: string;
  value: number;
  change: number;
  icon: string;
  trend: 'up' | 'down' | 'neutral';
}

interface ChartData {
  revenue: Array<{ month: string; value: number }>;
  users: Array<{ month: string; value: number }>;
}

@Component({
  selector: 'app-analytics',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  // KPI Cards Data
  kpiCards: KpiData[] = [
    {
      label: 'Total Revenue',
      value: 124500,
      change: 12.5,
      icon: 'fa-dollar-sign',
      trend: 'up'
    },
    {
      label: 'Active Users',
      value: 8542,
      change: 8.3,
      icon: 'fa-users',
      trend: 'up'
    },
    {
      label: 'Conversion Rate',
      value: 3.2,
      change: -0.5,
      icon: 'fa-percentage',
      trend: 'down'
    },
    {
      label: 'Avg Session',
      value: 4.5,
      change: 2.1,
      icon: 'fa-clock',
      trend: 'up'
    }
  ];

  // Chart Data
  chartData: ChartData = {
    revenue: [
      { month: 'Jan', value: 85000 },
      { month: 'Feb', value: 92000 },
      { month: 'Mar', value: 88000 },
      { month: 'Apr', value: 102000 },
      { month: 'May', value: 115000 },
      { month: 'Jun', value: 124500 }
    ],
    users: [
      { month: 'Jan', value: 5400 },
      { month: 'Feb', value: 5800 },
      { month: 'Mar', value: 6100 },
      { month: 'Apr', value: 6800 },
      { month: 'May', value: 7500 },
      { month: 'Jun', value: 8542 }
    ]
  };

  // Activity Feed
  activityData = [
    {
      action: 'New user registered',
      timestamp: '2 minutes ago',
      icon: 'fa-user-plus',
      color: 'primary'
    },
    {
      action: 'Payment received',
      timestamp: '15 minutes ago',
      icon: 'fa-dollar-sign',
      color: 'success'
    },
    {
      action: 'User session ended',
      timestamp: '1 hour ago',
      icon: 'fa-sign-out-alt',
      color: 'info'
    }
  ];

  // Chart instances for cleanup
  private revenueChart: Chart | null = null;
  private usersChart: Chart | null = null;

  ngOnInit() {
    // Initialize charts with animation
    this.initializeCharts();
  }

  ngOnDestroy() {
    // Cleanup chart instances
    this.revenueChart?.destroy();
    this.usersChart?.destroy();
  }

  // Initialize Chart.js instances
  initializeCharts() {
    // Revenue chart
    const ctxRevenue = document.getElementById('revenueChart') as HTMLCanvasElement;
    if (ctxRevenue) {
      this.revenueChart = new Chart(ctxRevenue.getContext('2d'), {
        type: 'line',
        data: {
          labels: this.chartData.revenue.map(d => d.month),
          datasets: [{
            label: 'Revenue',
            data: this.chartData.revenue.map(d => d.value),
            borderColor: 'rgb(13, 202, 240)',
            backgroundColor: 'rgba(13, 202, 240, 0.1)',
            tension: 0.4,
            fill: true
          }]
        },
        options: {
          responsive: true,
          plugins: {
            legend: { display: false }
          },
          scales: {
            y: { beginAtZero: false }
          }
        }
      });
    }

    // Users chart
    const ctxUsers = document.getElementById('usersChart') as HTMLCanvasElement;
    if (ctxUsers) {
      this.usersChart = new Chart(ctxUsers.getContext('2d'), {
        type: 'bar',
        data: {
          labels: this.chartData.users.map(d => d.month),
          datasets: [{
            label: 'Users',
            data: this.chartData.users.map(d => d.value),
            backgroundColor: 'rgba(25, 135, 245, 0.6)',
            borderColor: 'rgb(25, 135, 245)',
            borderWidth: 1
          }]
        },
        options: {
          responsive: true,
          plugins: {
            legend: { display: false }
          }
        }
      });
    }
  }
}
