import { Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard';
import { WarehouseManagerHomeComponent } from './pages/warehouse-manager-home/warehouse-manager-home';
import { PackerDashboardComponent } from './pages/packer-dashboard/packer-dashboard';
import { DriverDashboardComponent } from './pages/driver-dashboard/driver-dashboard';
import { StocktakerDashboardComponent } from './pages/stocktaker-dashboard/stocktaker-dashboard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admin-dashboard', component: AdminDashboardComponent },
  { path: 'warehouse-manager-home', component: WarehouseManagerHomeComponent },
  { path: 'packer-dashboard', component: PackerDashboardComponent },
  { path: 'driver-dashboard', component: DriverDashboardComponent },
  { path: 'stocktaker-dashboard', component: StocktakerDashboardComponent }
];
