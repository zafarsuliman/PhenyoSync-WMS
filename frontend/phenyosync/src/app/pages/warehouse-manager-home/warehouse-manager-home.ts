import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from '../../components/topbar/topbar';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-warehouse-manager-home',
  standalone: true,
  imports: [CommonModule, TopbarComponent, SidebarComponent],
  templateUrl: './warehouse-manager-home.component.html',
  styleUrls: ['./warehouse-manager-home.component.css']
})
export class WarehouseManagerHomeComponent {
  menuItems = [
    { name: 'Home', active: true },
    { name: 'Search Stock' },
    { name: 'Update Stock' },
    { name: 'Record Damaged / Lost Stock' },
    { name: 'Inventory Overview' },
    { name: 'Goods Received' },
    { name: 'View Reports' },
    { name: 'Logout' }
  ];

  actions = [
    { title: 'Search Stock', description: 'View and search current stock levels.' },
    { title: 'Update Stock', description: 'Update stock quantities after receiving or dispatching.' },
    { title: 'Record Damaged / Lost Stock', description: 'Capture damaged, spoiled, or missing stock.' },
    { title: 'Inventory Overview', description: 'Review stock availability and levels.' },
    { title: 'Goods Received', description: 'Record newly received supplier goods.' },
    { title: 'Reports', description: 'View warehouse-related reports.' }
  ];
}
