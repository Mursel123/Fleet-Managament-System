import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Chauffeur } from 'src/app/models/chauffeur';
import { RijbewijsType } from 'src/app/models/enums/rijbewijsType';
import { AlertService } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';
import { ChauffeurService } from 'src/app/services/chauffeur.service';

@Component({
  selector: 'app-chauffeur-detail',
  templateUrl: './chauffeur-detail.component.html',
  styleUrls: ['./chauffeur-detail.component.scss']
})
export class ChauffeurDetailComponent implements OnInit {
  isAdmin = false
  role: string = ''
  chauffeur = {} as Chauffeur
  rijbewijstTypeEnum = RijbewijsType
  private router = inject(Router)
  private authService = inject(AuthService)
  private toast = inject(AlertService)
  constructor(private route: ActivatedRoute, private chauffeurService: ChauffeurService){}


  getUserRole(): void {
    this.role = this.authService.getUserRole()
    if (this.role === 'Admin') {
        this.isAdmin = true;
    }
    else{
        this.isAdmin = false;
    }
  
  }

  activeChauffeur(active: boolean, id: string){
    this.chauffeurService.activeChauffeur(active, id).subscribe( 
      {
        next: () => 
        {
          window.location.reload()
        },
          error: () => this.toast.showErrorUpdate("chauffeur")
      })
    };

    navigateToUpdate(id: string){
      this.router.navigate(['chauffeur-update', id])
    }

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.chauffeur = data['chauffeur'];
    });
    this.getUserRole()
  }
}
