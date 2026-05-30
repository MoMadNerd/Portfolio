import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  // Current year for footer
  currentYear = new Date().getFullYear();

  // Title for browser tab
  title = 'Mohammad Thiab - Full Stack Developer';

  // Page-specific meta data
  metaTags = {
    description: 'Full-stack .NET developer portfolio showcasing web development, API design, and mobile app development skills.',
    keywords: '.NET, ASP.NET Core, Angular, React, C#, Azure, REST API, Database Design, Full Stack, Freelance',
    author: 'Mohammad Thiab'
  };
}
