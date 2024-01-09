import { Component, Input, OnInit, inject } from '@angular/core';
import { NgForm } from '@angular/forms';

import { Chauffeur } from 'src/app/models/chauffeur';
import { CreateChauffeur } from 'src/app/models/chauffeur-create';
import { Geslacht } from 'src/app/models/enums/geslacht';
import { RijbewijsType } from 'src/app/models/enums/rijbewijsType';
import { TankkaartSelectList } from 'src/app/models/tankkaart-selectlist';
import { AlertService } from 'src/app/services/alert.service';
import { ChauffeurService } from 'src/app/services/chauffeur.service';
import { TankkaartService } from 'src/app/services/tankkaart.service';

@Component({
  selector: 'app-chauffeur-new',
  templateUrl: './chauffeur-new.component.html',
  styleUrls: ['./chauffeur-new.component.scss']
})
export class ChauffeurNewComponent implements OnInit {


  @Input() chauffeur = {
    rijbewijsType: null,
    tankkaartId: null
  } as CreateChauffeur;

  private toast = inject(AlertService)
  private chauffeurService = inject(ChauffeurService)
  private tankkaartService = inject(TankkaartService)
  rijbewijsType = RijbewijsType;
  geslachten = Geslacht;
  errorMessage: string = "";
  tankkaarten: TankkaartSelectList[] = [];

  submitChauffeur(form: NgForm) {

    if (form.valid) {

      this.chauffeurService.createChauffeur(this.chauffeur).subscribe({
        next: () => {
          this.toast.showSuccessCreate("Chauffeur")
          this.chauffeur = {rijbewijsType: null, tankkaartId: null} as CreateChauffeur
        },
        error: () => this.toast.showErrorCreate("chauffeur")
      })
      }
  }


  ngOnInit(): void {
    this.readTankkaarten();
  };



  readTankkaarten() {
    this.tankkaartService
      .readTankkaartenSelectList()
      .subscribe((data) => {
        this.tankkaarten = data;
      });
  }

  
}
