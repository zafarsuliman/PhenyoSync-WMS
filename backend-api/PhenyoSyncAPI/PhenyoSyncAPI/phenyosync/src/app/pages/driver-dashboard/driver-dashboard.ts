import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from '../../components/topbar/topbar';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-driver-dashboard',
  standalone: true,
  imports: [CommonModule, TopbarComponent, SidebarComponent],
  templateUrl: './driver-dashboard.component.html',
  styleUrls: ['./driver-dashboard.component.css']
})
export class DriverDashboardComponent {
  menuItems = [
    { name: 'Driver Dashboard', active: true },
    { name: 'View Deliveries' },
    { name: 'Update Delivery Status' },
    { name: 'Delivery Route' },
    { name: 'Report Issue' },
    { name: 'Logout' }
  ];

  deliveries = [
    { order: 'SO-001', customer: 'Customer A', status: 'Pending' },
    { order: 'SO-002', customer: 'Customer B', status: 'In Transit' },
    { order: 'SO-003', customer: 'Customer C', status: 'Delivered' }
  ];
}
