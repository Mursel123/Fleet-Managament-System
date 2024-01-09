import { inject } from '@angular/core';
import { CanActivateFn, Route, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map, take } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';

export const authGuard: CanActivateFn = (route, state, router: Router = inject(Router)) => {

  const oidc = inject(OidcSecurityService);

  return oidc.isAuthenticated$.pipe(take(1), map(({isAuthenticated}) => {
      if (isAuthenticated)
        return true

      router.navigate(['/landing']);
      return false
    }))
};
