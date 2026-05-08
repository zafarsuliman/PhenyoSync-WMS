import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from '../../components/topbar/topbar';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-packer-dashboard',
  standalone: true,
  imports: [CommonModule, TopbarComponent, SidebarComponent],
  templateUrl: './packer-dashboard.component.html',
  styleUrls: ['./packer-dashboard.component.css']
})
export class PackerDashboardComponent {
  menuItems = [
    { name: 'Packer Dashboard', active: true },
    { name: 'View Pick List' },
    { name: 'Pack Customer Order' },
    { name: 'Update Packing Status' },
    { name: 'Report Damaged Item' },
    { name: 'Logout' }
  ];

  actions = [
    { title: 'View Pick List', description: 'View items that need to be packed.' },
    { title: 'Pack Customer Order', description: 'Confirm products packed for delivery.' },
    { title: 'Update Packing Status', description: 'Update order packing progress.' },
    { title: 'Report Damaged Item', description: 'Record damaged items found while packing.' }
  ];
}
