import { NgModule } from '@angular/core';
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';
import { environment } from 'src/environments/environment';


@NgModule({
  declarations: [],
  imports: [
    AuthModule.forRoot({
      config: {
        authority: environment.authority,
        redirectUrl: `${environment.clientRoot}signin-callback`,
        postLogoutRedirectUri: `${environment.clientRoot}signout-callback`,
        clientId: environment.clientId,
        scope: 'openid profile fleetmanagementapi.write fleetmanagementapi.read roles email',
        responseType: 'code',
        logLevel: LogLevel.Debug,
        useRefreshToken: true,
        secureRoutes: [environment.writeApiUrl, environment.readApiUrl]
      },
    })
  ],
  exports: [AuthModule]
})
export class AuthConfigurationModule { }
