import { Component, OnInit, inject} from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AanvraagService } from '../services/aanvraag.service';
import { SignalrService } from '../services/signalr.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit{
   isAdmin = false
   role: string = ''
   aanvragenCount: number = 0
   authService = inject(AuthService)
   aanvragenService = inject(AanvraagService)
   signalRService = inject(SignalrService)

ngOnInit(): void {
  this.role = this.authService.getUserRole()
  if (this.role === 'Admin') {
      this.isAdmin = true;
      this.readAanvragenInBehandeling()
      this.signalRService.getMessageSubject().subscribe(() => {
        this.readAanvragenInBehandeling()
      })
  }
  else{
      this.isAdmin = false;
  }

} 

isSidebarOpen = true; // Initial state

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }
  readAanvragenInBehandeling(){
    this.aanvragenService.readAanvragenInBehandelingCount().subscribe(x => this.aanvragenCount = x)
  }
}
