import { CanActivateFn, ActivatedRouteSnapshot, Router } from '@angular/router';
import { inject } from '@angular/core';

export const roleGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {

  const router = inject(Router);

  const userRole = localStorage.getItem('role');

  const allowedRoles = route.data['roles'] as string[];

  if (userRole && allowedRoles.includes(userRole)) {
    return true;
  }

  router.navigate(['/login']);

  return false;
};