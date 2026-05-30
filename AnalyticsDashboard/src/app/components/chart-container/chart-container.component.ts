import { Component, Input, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { Chart, registerables } from 'chart.js';

// Register all Chart.js components
Chart.register(...registerables);

@Component({
  selector: 'app-chart-container',
  templateUrl: './chart-container.component.html',
  styleUrls: ['./chart-container.component.scss']
})
export class ChartContainerComponent implements OnInit, OnDestroy {
  @Input() type: 'line' | 'bar' | 'pie' | 'doughnut' = 'line';
  @Input() label: string = '';
  @Input() data: Array<{ month: string; value: number }> = [];
  @Input() options?: any;
  @Input() color: string = 'rgb(13, 202, 240)';

  private chartInstance: Chart | null = null;
  private destroyRef: ElementRef;

  constructor(private elementRef: ElementRef) {
    this.destroyRef = elementRef;
  }

  ngOnInit() {
    this.initializeChart();
  }

  ngOnDestroy() {
    this.destroyChart();
  }

  initializeChart() {
    const canvas = document.getElementById(this.label) as HTMLCanvasElement;
    if (!canvas) return;

    this.chartInstance = new Chart(canvas, {
      type: this.type,
      data: {
        labels: this.data.map(d => d.month),
        datasets: [{
          label: this.label,
          data: this.data.map(d => d.value),
          borderColor: this.color,
          backgroundColor: this.color + '20', // Add transparency
          tension: 0.4,
          fill: this.type === 'line',
          borderWidth: 2,
          pointRadius: 4,
          pointHoverRadius: 6
        }]
      },
      options: this.options || {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false
          },
          tooltip: {
            enabled: true,
            mode: 'index',
            intersect: false
          }
        },
        scales: {
          x: {
            grid: {
              display: false
            }
          },
          y: {
            beginAtZero: true,
            grid: {
              color: 'rgba(0, 0, 0, 0.05)'
            }
          }
        }
      }
    });
  }

  destroyChart() {
    if (this.chartInstance) {
      this.chartInstance.destroy();
      this.chartInstance = null;
    }
  }

  updateData(newData: Array<{ month: string; value: number }>) {
    if (this.chartInstance) {
      this.chartInstance.data.datasets[0].data = newData.map(d => d.value);
      this.chartInstance.update();
    }
  }
}
