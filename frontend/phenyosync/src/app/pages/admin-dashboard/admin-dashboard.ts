import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { TopbarComponent } from '../../components/topbar/topbar';

import { SidebarComponent } from '../../components/sidebar/sidebar';

import { UserService } from '../../services/user';

@Component({
  selector: 'app-admin-dashboard',

  standalone: true,

  imports: [
    CommonModule,
    FormsModule,
    TopbarComponent,
    SidebarComponent
  ],

  templateUrl: './admin-dashboard.component.html',

  styleUrls: ['./admin-dashboard.component.css']
})

export class AdminDashboardComponent implements OnInit {

  users: any[] = [];

  searchText = '';

  activeSection = 'manage';

  currentUser: any = null;

  canManageUsers = false;

  newUser = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    roleId: 1
  };

  selectedUser: any = null;

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

  constructor(
    private userService: UserService
  ) { }

  ngOnInit(): void {

    this.loadUsers();

    const storedUser = localStorage.getItem('user');

    this.currentUser = storedUser
      ? JSON.parse(storedUser)
      : null;

    const allowedRoles = [
      'CEO',
      'COO',
      'BusinessManager'
    ];

    this.canManageUsers =
      allowedRoles.includes(this.currentUser?.role);

  }

  loadUsers() {

    this.userService.getUsers()
      .subscribe({

        next: (data: any) => {

          this.users = data;

        },

        error: () => {

          alert('Could not load users');

        }

      });

  }

  showSection(section: string) {

    this.activeSection = section;

  }

  registerUser() {

    this.userService.createUser(this.newUser)
      .subscribe({

        next: () => {

          alert('User registered successfully');

          this.loadUsers();

          this.showSection('manage');

        },

        error: () => {

          alert('Could not register user');

        }

      });

  }

  editUser(user: any) {

    this.selectedUser = {
      ...user
    };

    this.activeSection = 'edit';

  }

  deleteUser(user: any) {

    const confirmed = confirm(
      `Delete ${user.firstName} ${user.lastName}?`
    );

    if (!confirmed) return;

    this.userService.deleteUser(user.userId)
      .subscribe({

        next: () => {

          alert('User deleted');

          this.loadUsers();

        },

        error: () => {

          alert('Delete failed');

        }

      });

  }

  logout() {

    localStorage.clear();

    window.location.href = '/';

  }

  get filteredUsers() {

    if (!this.searchText) {

      return this.users;

    }

    const search =
      this.searchText.toLowerCase();

    return this.users.filter((user: any) =>

      user.firstName?.toLowerCase().includes(search)
      ||

      user.lastName?.toLowerCase().includes(search)
      ||

      user.email?.toLowerCase().includes(search)
      ||

      user.role?.toLowerCase().includes(search)

    );

  }

}