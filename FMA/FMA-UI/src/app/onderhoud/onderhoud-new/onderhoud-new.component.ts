import { Component, Input, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { GarageSelectList } from 'src/app/models/garage-selectlist';
import { CreateOnderhoud } from 'src/app/models/onderhoud-create';
import { GarageService } from 'src/app/services/garage.service';
import { OnderhoudService } from 'src/app/services/onderhoud.service';

@Component({
  selector: 'app-onderhoud-new',
  templateUrl: './onderhoud-new.component.html',
  styleUrls: ['./onderhoud-new.component.scss']
})
export class OnderhoudNewComponent implements OnInit{
  
  private onderhoudService = inject(OnderhoudService)
  private garagesService = inject(GarageService)
  private route = inject(ActivatedRoute)
  private router = inject(Router)

  garages: GarageSelectList[] = [];

  @Input() onderhoud = {
    bestandType: 0,
    garageId: null
  } as CreateOnderhoud;

  ngOnInit(): void {
    this.readGarages()
    this.route.params.subscribe(params => {
      if(params['aanvraagId']) {
        this.onderhoud.aanvraagId = params['aanvraagId']
        };
        if(params['voertuigId']) {
          this.onderhoud.voertuigId = params['voertuigId']
        };
      }) 
    };
  

  submitOnderhoud() {
    this.onderhoudService.createOnderhoud(this.onderhoud)
    this.router.navigate(['..'])
  }
  

  onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const file: File = (inputElement.files as FileList)[0];

    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        const base64data: string = (reader.result as string).split(',')[1];
        this.onderhoud.fileData = base64data
        this.onderhoud.fileName = file.name
      
      };
      reader.readAsDataURL(file);
    }
  }

  readGarages(){
    this.garagesService.readGaragesSelectList()
      .subscribe(data => this.garages = data)
  }
}
