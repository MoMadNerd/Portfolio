import { Component } from '@angular/core';

export interface ActivityItem {
  action: string;
  timestamp: string;
  icon: string;
  color: 'primary' | 'success' | 'info' | 'warning' | 'danger';
  userId?: string;
  avatar?: string;
}

@Component({
  selector: 'app-activity-feed',
  templateUrl: './activity-feed.component.html',
  styleUrls: ['./activity-feed.component.scss']
})
export class ActivityFeedComponent {
  activityItems: ActivityItem[] = [
    {
      action: 'New user registered',
      timestamp: '2 minutes ago',
      icon: 'user-plus',
      color: 'primary',
      userId: 'john_doe',
      avatar: 'JD'
    },
    {
      action: 'Payment received ($500)',
      timestamp: '15 minutes ago',
      icon: 'dollar-sign',
      color: 'success',
      userId: 'admin'
    },
    {
      action: 'User session ended',
      timestamp: '1 hour ago',
      icon: 'sign-out-alt',
      color: 'info'
    },
    {
      action: 'Order #12345 completed',
      timestamp: '2 hours ago',
      icon: 'shopping-cart',
      color: 'primary',
      userId: 'seller_01'
    },
    {
      action: 'File uploaded',
      timestamp: '3 hours ago',
      icon: 'upload',
      color: 'warning',
      userId: 'designer'
    }
  ];

  // Color mapping
  getColorClass(color: string): string {
    const colors: Record<string, string> = {
      primary: 'primary',
      success: 'success',
      info: 'info',
      warning: 'warning',
      danger: 'danger'
    };
    return colors[color] || 'primary';
  }
}
