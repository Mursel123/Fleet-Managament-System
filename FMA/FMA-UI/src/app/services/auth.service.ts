import { EventEmitter, Injectable } from '@angular/core';
import { OidcSecurityService, LoginResponse } from 'angular-auth-oidc-client';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();

  private role: string = ''
  private userInfo: string = ''

  constructor(private oidcSecurityService: OidcSecurityService) {
    this.oidcSecurityService.checkAuth().subscribe((loginResponse: LoginResponse) => {
      this.isLoggedInSubject.next(loginResponse.isAuthenticated);

    });
  }

  getUserRole(): string {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((loginResponse: LoginResponse) => {
        const {userData} =
        
          this.role = loginResponse.userData.role;

      });
      
      return this.role
  }

  getUserInfo(): string {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((loginResponse: LoginResponse) => {
          this.userInfo = `Welkom, ${loginResponse.userData.email} (${loginResponse.userData.role})`;
      });
      
      return this.userInfo
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {

    this.oidcSecurityService.logoffAndRevokeTokens().subscribe( () => {
      this.isLoggedInSubject.next(false); 

    });
    

  }
}
