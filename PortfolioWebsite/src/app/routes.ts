import { Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { ProjectsComponent } from './projects/projects.component';
import { ContactComponent } from './contact/contact.component';

/**
 * Application Routes
 * Defines all navigation paths and their corresponding components
 */
export const routes: Routes = [
  {
    path: '',
    redirectTo: '/about',
    pathMatch: 'full'
  },
  {
    path: 'about',
    component: AboutComponent,
    title: 'About - Mohammad Thiab Portfolio'
  },
  {
    path: 'projects',
    component: ProjectsComponent,
    title: 'Projects - Mohammad Thiab Portfolio'
  },
  {
    path: 'contact',
    component: ContactComponent,
    title: 'Contact - Mohammad Thiab Portfolio'
  },
  {
    path: '**',
    redirectTo: '/about'
  }
];
