import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.css']
})
export class TopbarComponent {

  user: any = JSON.parse(localStorage.getItem('user') || '{}');

  constructor(private router: Router) { }

  logout() {
    localStorage.removeItem('user');
    this.router.navigate(['/']);
  }
}
