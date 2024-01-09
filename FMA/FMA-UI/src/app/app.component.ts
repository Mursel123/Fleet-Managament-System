import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { AanvraagService } from './services/aanvraag.service';
import { Observable } from 'rxjs';
import { Aanvraag } from './models/aanvraag/aanvraag';
import { AanvraagNotification } from './models/aanvraag/aanvraag-notification';
import { AanvraagType } from './models/enums/aanvraagType';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']

})
export class AppComponent implements OnInit {

  showDropdown = false
  isLoggedIn = false;
  userInfo: string = ''
  authService = inject(AuthService)
  aanvraagService = inject(AanvraagService)
  router = inject(Router)
  signalRService = inject(SignalrService)
  aanvragen!: AanvraagNotification[]


  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe(result =>{
      this.isLoggedIn = result 
      if(result){
        this.userInfo = this.authService.getUserInfo()
        this.readNotifications()
  
        this.signalRService.getMessageSubject().subscribe(() => {
          this.readNotifications()
        })};
    })

  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/landing'])

  }

  showDropdownList(show: boolean){
    this.showDropdown = show
  }

  navigateToCompleteAaanvraag(aanvraagId: string, voertuigId: string, aanvraagType: AanvraagType){
    if(aanvraagType == AanvraagType.Onderhoud){
      this.router.navigate(['onderhoud-new', aanvraagId, voertuigId]);
    }
    else if(aanvraagType == AanvraagType.Herstelling){
      this.router.navigate(['herstelling-new', aanvraagId, voertuigId]);
    }
    this.showDropdown = false
  }
  readNotifications(){
    this.aanvraagService.readAanvragenNotification()
        .subscribe(x => this.aanvragen = x )
  }
}
