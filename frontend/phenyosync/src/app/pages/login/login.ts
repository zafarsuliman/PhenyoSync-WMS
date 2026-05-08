import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  user = {
    email: '',
    password: ''
  };

  errorMessage = '';
  loading = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  login() {
    if (!this.user.email || !this.user.password) {
      this.errorMessage = 'Please enter email and password';
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.authService.login(this.user).subscribe({
      next: (res: any) => {
        this.loading = false;

        localStorage.setItem('user', JSON.stringify(res));

        const roleRoutes: any = {
          AdminClerk: '/admin-dashboard',
          WarehouseManager: '/warehouse-manager-home',
          Packer: '/packer-dashboard',
          Driver: '/driver-dashboard',
          StockTaker: '/stocktaker-dashboard'
        };

        const route = roleRoutes[res.role];

        if (route) {
          this.router.navigate([route]);
        } else {
          this.errorMessage = 'Unknown user role';
        }
      },
      error: () => {
        this.loading = false;
        this.errorMessage = 'Invalid email or password';
      }
    });
  }
}
