import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent {
  projects: Project[] = [
    {
      id: 1,
      name: 'Task Manager API',
      description: 'A RESTful API built with ASP.NET Core to manage tasks and todo lists.',
      tech: ['ASP.NET Core', 'Entity Framework', 'SQL Server', 'Swagger'],
      features: ['RESTful API Design', 'CRUD Operations', 'Swagger Documentation'],
      github: 'https://github.com/mthiab/task-manager-api'
    },
    {
      id: 2,
      name: 'User Authentication API',
      description: 'Secure authentication API with JWT, token refresh, and logout functionality.',
      tech: ['ASP.NET Core', 'JWT', 'Identity', 'CORS'],
      features: ['JWT Authentication', 'Token Refresh', 'Secure Logout'],
      github: 'https://github.com/mthiab/auth-api'
    },
    {
      id: 3,
      name: 'Expenses Tracker App',
      description: 'Flutter mobile app for tracking income and expenses with Hive local database.',
      tech: ['Flutter', 'Dart', 'Hive'],
      features: ['Income/Expense Tracking', 'Balance Calculations', 'Data Persistence'],
      github: 'https://github.com/mthiab/expenses-tracker'
    },
    {
      id: 4,
      name: 'E-Commerce Web App',
      description: 'Full-featured e-commerce application with user management and secure checkout.',
      tech: ['ASP.NET Core', 'Angular', 'SQL Server'],
      features: ['User Management', 'Shopping Cart', 'Secure Checkout'],
      github: 'https://github.com/mthiab/ecommerce-app'
    }
  ];

  filter = 'all';
}

export interface Project {
  id: number;
  name: string;
  description: string;
  tech: string[];
  features: string[];
  github: string;
}
