import { Component } from '@angular/core';

@Component({
  selector: 'app-revenue-chart',
  template: `
    <div class="chart-container">
      <canvas id="revenueChart" width="400" height="200"></canvas>
    </div>
  `
})
export class RevenueChartComponent {
  // Chart configuration for revenue line chart
  get chartConfig() {
    return {
      type: 'line',
      data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        datasets: [{
          label: 'Revenue',
          data: [85000, 92000, 88000, 102000, 115000, 124500],
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
    };
  }
}
