import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from '../../components/topbar/topbar';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-stocktaker-dashboard',
  standalone: true,
  imports: [CommonModule, TopbarComponent, SidebarComponent],
  templateUrl: './stocktaker-dashboard.component.html',
  styleUrls: ['./stocktaker-dashboard.component.css']
})
export class StocktakerDashboardComponent {
  menuItems = [
    { name: 'Stock Taker Dashboard', active: true },
    { name: 'Start Stock Take' },
    { name: 'Capture Counted Stock' },
    { name: 'View Stock Differences' },
    { name: 'Submit Stock Take' },
    { name: 'Logout' }
  ];

  stockItems = [
    { product: 'Rice 10kg', systemQty: 50, countedQty: 48 },
    { product: 'Cooking Oil 2L', systemQty: 80, countedQty: 80 },
    { product: 'Maize Meal 12.5kg', systemQty: 35, countedQty: 33 }
  ];
}
