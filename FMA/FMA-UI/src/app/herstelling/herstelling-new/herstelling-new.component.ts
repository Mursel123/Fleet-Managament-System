import { Component, Input, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CreateHerstelling } from 'src/app/models/herstelling-create';
import { HerstellingService } from 'src/app/services/herstelling.service';
import { VerzekeringsmaatschappijSelectList } from 'src/app/models/verzekeringsmaatschappij-selectlist';
import { GemeldeSchadeSelectList } from 'src/app/models/gemeldeSchade-selectlist';
import { VerzekeringsmaatschappijService } from 'src/app/services/verzkeringsmaatschappij.service';
import { GemeldeSchadeService } from 'src/app/services/gemelde-schade.service';
import { BestandType } from 'src/app/models/enums/bestandType';
import { Document } from 'src/app/models/document';
import { AlertService } from 'src/app/services/alert.service';


@Component({
  selector: 'app-herstelling-new',
  templateUrl: './herstelling-new.component.html',
  styleUrls: ['./herstelling-new.component.scss']
})
export class HerstellingNewComponent {
  private herstellingService = inject(HerstellingService)
  private route = inject(ActivatedRoute)
  private verzekeringsmaatschappijService = inject(VerzekeringsmaatschappijService)
  private gemeldeSchadeService = inject(GemeldeSchadeService)
  private toast = inject(AlertService)

  verzekeringsmaatschappijen: VerzekeringsmaatschappijSelectList[] = []
  gemeldeSchades: GemeldeSchadeSelectList[] = []
  @Input() herstelling = {
  gemeldeSchadeId: null,
  documenten: [] as Document[]
  } as CreateHerstelling;

  ngOnInit(): void {
    this.readVerzekeringsmaatsschappijSelectList()
    this.readGemeldeSchadeSelectList()
    this.route.params.subscribe(params => {
      if(params['aanvraagId']) {
        this.herstelling.aanvraagId = params['aanvraagId']
        };
        if(params['voertuigId']) {
          this.herstelling.voertuigId = params['voertuigId']
        };
      }) 
    };
  

  submitHerstelling() {
    this.herstellingService.createHerstelling(this.herstelling).subscribe({
        next: () => this.toast.showSuccessCreate("Aanvraag"),
        error: () => this.toast.showErrorCreate("Aanvraag")
    })

  }
  

  onFilesSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const files: FileList | null = inputElement.files;

    if (files && files.length > 0) {

        for (let i = 0; i < files.length; i++) {
          var extension = files[i].name.split('.').pop()?.toLowerCase();
          if(extension === 'pdf' || extension === 'jpg' || extension === 'jpeg' || extension === 'png'){
            const reader = new FileReader();
            reader.onloadend = () => {
                const base64data: string = (reader.result as string).split(',')[1];
                //const base64data: string = (reader.result as string)
                const document: Document = {
                    fileData: base64data,
                    fileName: files[i].name,
                    bestandType: extension === 'pdf' ? BestandType.PDF : BestandType.PNG
                };
                this.herstelling.documenten.push(document);

            };
            reader.readAsDataURL(files[i]);
          }
          else{
            this.toast.showErrorCreateEmpty("Bestanden mogen alleen de volgende extensies bevatten: pdf, jpg, jpeg, png")
          }
            
        }
    }
}
  

  readVerzekeringsmaatsschappijSelectList(){
   this.verzekeringsmaatschappijService.readVerzekeringsmaatschappijenSelectList().subscribe(x => this.verzekeringsmaatschappijen = x)
  }
  readGemeldeSchadeSelectList(){
    this.gemeldeSchadeService.readGemeldeSchadeSelectList().subscribe(x => this.gemeldeSchades = x)
  }
}
