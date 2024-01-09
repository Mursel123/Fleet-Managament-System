import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, provideAnimations } from "@angular/platform-browser/animations";
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CommonModule, DatePipe } from '@angular/common';
import { AbstractSecurityStorage, AuthInterceptor } from 'angular-auth-oidc-client';
import { ChauffeurTableComponent } from './chauffeur/components/chauffeur-table/chauffeur-table.component';
import { ChauffeurDetailComponent } from './chauffeur/components/chauffeur-detail/chauffeur-detail.component';
import { ChauffeurNewComponent } from './chauffeur/components/chauffeur-new/chauffeur-new.component';
import { SelectListPipe } from './pipes/select-list.pipe';
import { ChauffeurUpdateComponent } from './chauffeur/components/chauffeur-update/chauffeur-update.component';
import { EnumPipe } from './pipes/enum.pipe';
import { LoginCallbackComponent } from './account/login-callback/login-callback.component';
import { LogoutCallbackComponent } from './account/logout-callback/logout-callback.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UnauthorizedComponent } from './account/unauthorized/unauthorized.component';
import { LandingComponent } from './components/landing/landing.component';
import { VoertuigTableComponent } from './voertuig/voertuig-table/voertuig-table.component';
import { AgGridModule } from 'ag-grid-angular';
import { VoertuigDetailComponent } from './voertuig/voertuig-detail/voertuig-detail.component';
import { AanvraagAdminTableComponent } from './aanvraag/aanvraag-admin-table/aanvraag-admin-table.component';
import { AanvraagDetailComponent } from './aanvraag/aanvraag-detail/aanvraag-detail.component';
import { AanvraagChauffeurComponent } from './aanvraag/aanvraag-chauffeur/aanvraag-chauffeur.component';
import { AanvraagNewComponent } from './aanvraag/aanvraag-new/aanvraag-new.component';
import { OnderhoudNewComponent } from './onderhoud/onderhoud-new/onderhoud-new.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskDirective, provideEnvironmentNgxMask, IConfig, provideNgxMask, NgxMaskPipe } from 'ngx-mask';
import { provideToastr } from 'ngx-toastr';
import { HerstellingNewComponent } from './herstelling/herstelling-new/herstelling-new.component';
import { AuthConfigurationModule } from './auth-configuration.module';
import { MinAgeDirective } from './chauffeur/components/chauffeur-new/min-age.directive';
import { MyStorageService } from './services/my-storage.service';

const maskConfig: Partial<IConfig> = {
  validation: true,

};


@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    ChauffeurTableComponent,
    ChauffeurDetailComponent,
    ChauffeurNewComponent,
    SelectListPipe,
    ChauffeurUpdateComponent,
    EnumPipe,
    LoginCallbackComponent,
    LogoutCallbackComponent,
    DashboardComponent,
    UnauthorizedComponent,
    LandingComponent,
    VoertuigTableComponent,
    VoertuigDetailComponent,
    AanvraagAdminTableComponent,
    AanvraagDetailComponent,
    AanvraagChauffeurComponent,
    AanvraagNewComponent,
    OnderhoudNewComponent,
    HerstellingNewComponent,
    MinAgeDirective

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AgGridModule,
    CommonModule,
    NgxMaskDirective,
    NgxMaskPipe,
    AppRoutingModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    AuthConfigurationModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }, 
    { provide: AbstractSecurityStorage, useClass: MyStorageService },
    EnumPipe, DatePipe, provideAnimations(), provideToastr(), provideEnvironmentNgxMask(maskConfig), provideNgxMask()],
  bootstrap: [AppComponent]
})
export class AppModule { }
