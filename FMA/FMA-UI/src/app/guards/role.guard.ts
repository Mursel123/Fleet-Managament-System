import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const roleGuard: CanActivateFn = (route, state, router: Router = inject(Router)) => {
  const authService = inject(AuthService);
  let role:string
  role = authService.getUserRole()
    if (role === 'Admin') {
      return true
    }
    return router.parseUrl('/unauthorized')
};
