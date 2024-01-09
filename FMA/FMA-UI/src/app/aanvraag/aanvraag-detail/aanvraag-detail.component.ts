import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as JSZip from 'jszip';
import * as FileSaver from 'file-saver';
import { Aanvraag } from 'src/app/models/aanvraag/aanvraag';
import { Document } from 'src/app/models/document';
import { AanvraagType } from 'src/app/models/enums/aanvraagType';
import { BestandType } from 'src/app/models/enums/bestandType';
import { BrandstofType } from 'src/app/models/enums/brandstofType';
import { StatusType } from 'src/app/models/enums/statusType';
import { WagenType } from 'src/app/models/enums/wagenType';
import { AanvraagService } from 'src/app/services/aanvraag.service';
import { AuthService } from 'src/app/services/auth.service';
import { FileService } from 'src/app/services/file.service';



@Component({
  selector: 'app-aanvraag-detail',
  templateUrl: './aanvraag-detail.component.html',
  styleUrls: ['./aanvraag-detail.component.scss']
})
export class AanvraagDetailComponent {
  isAdmin = false
  role: string = ''
  aanvraag = {} as Aanvraag
  
  private authService = inject(AuthService)
  private route = inject(ActivatedRoute)
  private aanvraagService = inject(AanvraagService)
  private fileService = inject(FileService)

  getUserRole(): void {
    this.role = this.authService.getUserRole()
    if (this.role === 'Admin') {
        this.isAdmin = true;
    }
    else{
        this.isAdmin = false;
    }
  
  }

downloadBestandOnderhoud(document: Document){
  this.fileService.downloadBase64File(document.fileData, document.fileName, 'application/pdf')
}
downloadBestandHerstelling(documenten: Document[], id: string){
  documenten = documenten.filter(x => x.bestandType === BestandType.PDF)
  const zip = new JSZip();
  for(let document of documenten){
    const byteCharacters = atob(document.fileData);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    zip.file(document.fileName, blob)
  }
  zip.generateAsync({type:"blob"})
    .then(function(content) {
        // see FileSaver.js
        FileSaver.saveAs(content, `Aanvraag_${id}.zip`);
    });
  
}
aanvraagGoedkeuren(id: string){
  this.aanvraagService.updateAanvraagStatus(StatusType.Goedgekeurd, id)
}

aanvraagAfwijzen(id: string){
  this.aanvraagService.updateAanvraagStatus(StatusType.Afgewezen, id)
}
  ngOnInit() {
    this.route.params.subscribe(params => {
      if(params['id']) {
        this.aanvraagService.readAanvraagById(params['id']).subscribe(data => {
          this.aanvraag = data;
        });
      }
    });
    this.getUserRole()
  }


  aanvraagType = AanvraagType
  statusType = StatusType
  brandstofType = BrandstofType
  wagenType = WagenType
}
