import { Component, OnInit, Input, Output } from '@angular/core';
import { UpdateChauffeur } from 'src/app/models/chauffeur-update';
import { Chauffeur } from 'src/app/models/chauffeur';
import { ChauffeurService } from 'src/app/services/chauffeur.service';
import { ActivatedRoute } from '@angular/router';
import { TankkaartSelectList } from 'src/app/models/tankkaart-selectlist';
import { RijbewijsType } from 'src/app/models/enums/rijbewijsType';
import { TankkaartService } from 'src/app/services/tankkaart.service';

@Component({
  selector: 'app-chauffeur-update',
  templateUrl: './chauffeur-update.component.html',
  styleUrls: ['./chauffeur-update.component.scss']
})
export class ChauffeurUpdateComponent implements OnInit {

  constructor(private route: ActivatedRoute, private chauffeurService: ChauffeurService, private tankkaartService: TankkaartService){
    
  }
  itemId: string = '';
  public chauffeurUpdate = {} as UpdateChauffeur;


  tankkaarten: TankkaartSelectList[] = [];
  rijbewijsType =  RijbewijsType;

  ngOnInit(): void {
    this.getChauffeur();
    this.readTankkaarten();
  }

  getChauffeur() {
    this.route.params.subscribe(params => {
      this.itemId = params['id']; 
      this.chauffeurService.readChauffeurById(this.itemId).subscribe(data => {
        this.chauffeurUpdate.id = data.id
        this.chauffeurUpdate.naam = data.naam
        this.chauffeurUpdate.voornaam = data.voornaam
        this.chauffeurUpdate.straat = data.adres.straat
        this.chauffeurUpdate.nummer = data.adres.nummer
        this.chauffeurUpdate.bus = data.adres.bus
        this.chauffeurUpdate.stad = data.gemeente ? data.gemeente.stad : ""
        this.chauffeurUpdate.postcode = data.gemeente ? data.gemeente.postcode : ""
        this.chauffeurUpdate.tankkaartId = data.tankkaart ? data.tankkaart.id : null
        this.chauffeurUpdate.email = data.email
        this.chauffeurUpdate.rijbewijsType = data.rijbewijsType
        this.chauffeurUpdate.isActief = true
      });
    });
    
  }

  updateChauffeur(){
    console.log(this.chauffeurUpdate)
    this.chauffeurService.updateChauffeur(this.chauffeurUpdate)
  }

  readTankkaarten() {
    this.tankkaartService
      .readTankkaartenSelectList()
      .subscribe((data) => {
        this.tankkaarten = data;
      });
  }

}

