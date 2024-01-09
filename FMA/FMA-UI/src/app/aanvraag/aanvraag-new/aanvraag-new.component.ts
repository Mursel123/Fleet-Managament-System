import { Component, Input, inject } from '@angular/core';
import { CreateAanvraag } from 'src/app/models/aanvraag/aanvraag-create';
import { AanvraagType } from 'src/app/models/enums/aanvraagType';
import { Location } from '@angular/common';
import { VoertuigSelectList } from 'src/app/models/voertuig-selectlist';
import { AanvraagService } from 'src/app/services/aanvraag.service';
import { VoertuigService } from 'src/app/services/voertuig.service';
import { AlertService } from 'src/app/services/alert.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-aanvraag-new',
  templateUrl: './aanvraag-new.component.html',
  styleUrls: ['./aanvraag-new.component.scss']
})
export class AanvraagNewComponent {

  private aanvraagService = inject(AanvraagService)
  private voertuigService = inject(VoertuigService)
  private location = inject(Location)
  private toast = inject(AlertService)

  @Input() aanvraag = {
    voertuigId: null,
  } as CreateAanvraag;

  voertuigen: VoertuigSelectList[] = [];
  aanvraagType =  AanvraagType;

  submitAanvraag(form: NgForm) {
    this.aanvraagService.createAanvraag(this.aanvraag).subscribe({
      next: () => 
      {
        this.toast.showSuccessCreate("Aanvraag")
        form.resetForm()
      },
      error: () => this.toast.showErrorCreate("Aanvraag")
    }
      )
  }
  
  
  ngOnInit(): void {
    this.readVoertuigen();
  };

      
      
  readVoertuigen() {
    this.voertuigService
      .readVoertuigenSelectList()
      .subscribe((data) => {
        this.voertuigen = data;
      });
}}
