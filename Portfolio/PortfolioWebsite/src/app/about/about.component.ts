import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent {
  name = 'Mohammad Thiab';
  role = 'Full-Stack .NET Developer';
  location = 'Ramallah, West Bank, Palestine';
  email = 'mohammad.m.thiab@outlook.com';
  phone = '+970 595 298 081';

  skills: string[] = [
    'C# / .NET / ASP.NET Core',
    'Entity Framework Core',
    'SQL Server / Hive DB',
    'REST API Design',
    'JWT Authentication',
    'Angular / TypeScript',
    'Flutter / Dart',
    'iOS / Android Development',
    'Git / GitHub',
    'Docker / CI/CD',
    'Clean Code'
  ];

  experience: Array<{ company: string; role: string; period: string; description: string }> = [
    {
      company: 'Private Company',
      role: 'Full Stack .NET Developer',
      period: 'Feb 2024 - Jul 2024',
      description: 'Developed full-stack web applications, API creation, database integration, cross-functional team collaboration.'
    },
    {
      company: 'Freelance',
      role: 'Flutter Developer',
      period: 'Aug 2023 - Nov 2023',
      description: 'Built responsive mobile applications for iOS & Android, cross-platform development.'
    },
    {
      company: 'Academic Project',
      role: 'Graduation Project',
      period: '2023',
      description: 'E-commerce web application with user management, product catalog, secure checkout.'
    }
  ];

  availability = 'Open to freelance projects and remote opportunities!';
}
