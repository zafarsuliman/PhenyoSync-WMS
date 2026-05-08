import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopbarComponent } from '../../components/topbar/topbar';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { UserService } from '../../services/user';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, TopbarComponent, SidebarComponent],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  users: any[] = [];

  menuItems = [
    { name: 'Admin Dashboard', active: true },
    { name: 'Business Manager Dashboard' },
    { name: 'Product List' },
    { name: 'Create / Edit Product' },
    { name: 'Inventory Overview' },
    { name: 'Goods Received (GRN)' },
    { name: 'Sales Order List' },
    { name: 'Supplier List' },
    { name: 'Reports Dashboard' },
    { name: 'Logout' }
  ];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe({
      next: (data: any) => this.users = data,
      error: () => alert('Could not load users from database')
    });
  }
}
