import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent {
  contactForm: {
    name: string;
    email: string;
    subject: string;
    message: string;
  } = {
    name: '',
    email: '',
    subject: '',
    message: ''
  };

  onSubmit(): void {
    // Handle form submission
    console.log('Form submitted:', this.contactForm);
    // In a real app, you would send this to a backend service
  }
}
