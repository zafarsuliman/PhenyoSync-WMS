import { Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login';

import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard';
import { WarehouseManagerHomeComponent } from './pages/warehouse-manager-home/warehouse-manager-home';
import { PackerDashboardComponent } from './pages/packer-dashboard/packer-dashboard';
import { DriverDashboardComponent } from './pages/driver-dashboard/driver-dashboard';
import { StocktakerDashboardComponent } from './pages/stocktaker-dashboard/stocktaker-dashboard';

import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

export const routes: Routes = [

  {
    path: '',
    component: LoginComponent
  },

  {
    path: 'admin-dashboard',
    component: AdminDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: {
      roles: ['Admin', 'AdminClerk', 'CEO', 'COO']
    }
  },

  {
    path: 'warehouse-manager-home',
    component: WarehouseManagerHomeComponent,
    canActivate: [authGuard, roleGuard],
    data: {
      roles: ['WarehouseManager']
    }
  },

  {
    path: 'packer-dashboard',
    component: PackerDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: {
      roles: ['Packer']
    }
  },

  {
    path: 'driver-dashboard',
    component: DriverDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: {
      roles: ['Driver']
    }
  },

  {
    path: 'stocktaker-dashboard',
    component: StocktakerDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: {
      roles: ['StockTaker']
    }
  },

  {
    path: '**',
    redirectTo: ''
  }

];