import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChauffeurTableComponent } from './chauffeur/components/chauffeur-table/chauffeur-table.component';
import { ChauffeurDetailComponent } from './chauffeur/components/chauffeur-detail/chauffeur-detail.component';
import { ChauffeurNewComponent } from './chauffeur/components/chauffeur-new/chauffeur-new.component';
import { ChauffeurUpdateComponent } from './chauffeur/components/chauffeur-update/chauffeur-update.component';
import { LoginCallbackComponent } from './account/login-callback/login-callback.component';
import { LogoutCallbackComponent } from './account/logout-callback/logout-callback.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { authGuard } from './guards/auth.guard';
import { UnauthorizedComponent } from './account/unauthorized/unauthorized.component';
import { LandingComponent } from './components/landing/landing.component';
import { roleGuard } from './guards/role.guard';
import { VoertuigTableComponent } from './voertuig/voertuig-table/voertuig-table.component';
import { VoertuigDetailComponent } from './voertuig/voertuig-detail/voertuig-detail.component';
import { AanvraagAdminTableComponent } from './aanvraag/aanvraag-admin-table/aanvraag-admin-table.component';
import { AanvraagDetailComponent } from './aanvraag/aanvraag-detail/aanvraag-detail.component';
import { AanvraagChauffeurComponent } from './aanvraag/aanvraag-chauffeur/aanvraag-chauffeur.component';
import { AanvraagNewComponent } from './aanvraag/aanvraag-new/aanvraag-new.component';
import { OnderhoudNewComponent } from './onderhoud/onderhoud-new/onderhoud-new.component';
import { HerstellingNewComponent } from './herstelling/herstelling-new/herstelling-new.component';
import { AutoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { chauffeurDetailResolver } from './resolvers/chauffeur-detail.resolver';

const routes: Routes = [
  {path: '', title: 'Dashboard', component:DashboardComponent, canActivate:[authGuard]},
  {path: 'chauffeurs', title: 'Chauffeurs Overview', component:ChauffeurTableComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard]},
  {path: 'voertuigen', title: 'Voertuigen Overview', component:VoertuigTableComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard]},
  {path: 'voertuig-detail/:id', title: 'Voertuig Detail', component:VoertuigDetailComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard]},
  {path: 'unauthorized', title: 'Unauthorized', component:UnauthorizedComponent},
  {path: 'landing', title: 'Home', component:LandingComponent},
  {path: 'chauffeur-detail/:id', title: 'Chauffeur Detail', component:ChauffeurDetailComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard], resolve:{chauffeur: chauffeurDetailResolver}},
  {path: 'chauffeur-detail', title: 'Chauffeur Detail', component:ChauffeurDetailComponent, canActivate:[AutoLoginPartialRoutesGuard], resolve:{chauffeur: chauffeurDetailResolver}},
  {path: 'chauffeur-new', title:"Nieuw Chauffeur" ,component: ChauffeurNewComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard] },
  {path: 'chauffeur-update/:id', title:"Chauffeur Update" ,component: ChauffeurUpdateComponent , canActivate:[AutoLoginPartialRoutesGuard, roleGuard] },
  {path: 'aanvragen-admin', title: 'Aanvragen Overview', component:AanvraagAdminTableComponent, canActivate:[AutoLoginPartialRoutesGuard, roleGuard]},
  {path: 'aanvragen', title: 'Aanvragen Overview', component:AanvraagChauffeurComponent, canActivate:[AutoLoginPartialRoutesGuard]},
  {path: 'aanvragen/:id', title: 'Aanvraag Detail', component:AanvraagDetailComponent, canActivate:[AutoLoginPartialRoutesGuard]},
  {path: 'aanvraag-new', title: 'Nieuw Aanvraag', component:AanvraagNewComponent, canActivate:[AutoLoginPartialRoutesGuard]},
  {path: 'onderhoud-new/:aanvraagId/:voertuigId', title: 'Nieuw Onderhoud', component:OnderhoudNewComponent, canActivate:[AutoLoginPartialRoutesGuard]},
  {path: 'herstelling-new/:aanvraagId/:voertuigId', title: 'Nieuw Herstelling', component:HerstellingNewComponent, canActivate:[AutoLoginPartialRoutesGuard]},
  {path: 'signin-callback', title:"Signing in" ,component: LoginCallbackComponent },
  {path: 'signout-callback', title:"Signing out" ,component: LogoutCallbackComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
