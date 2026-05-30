import { Component, Input } from '@angular/core';

export interface KpiCardData {
  label: string;
  value: number;
  change: number;
  icon: string;
  trend: 'up' | 'down' | 'neutral';
  color?: 'primary' | 'success' | 'warning' | 'info' | 'danger';
}

@Component({
  selector: 'app-kpi-card',
  templateUrl: './kpi-card.component.html',
  styleUrls: ['./kpi-card.component.scss']
})
export class KpiCardComponent {
  @Input() data!: KpiCardData;

  get bgColor(): string {
    const colors: Record<string, string> = {
      primary: 'bg-primary',
      success: 'bg-success',
      warning: 'bg-warning',
      info: 'bg-info',
      danger: 'bg-danger'
    };
    return colors[this.data.color || 'primary'];
  }
}
