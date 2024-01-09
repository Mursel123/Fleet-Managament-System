import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BrandstofType } from 'src/app/models/enums/brandstofType';
import { WagenType } from 'src/app/models/enums/wagenType';
import { Voertuig } from 'src/app/models/voertuig';
import { VoertuigService } from 'src/app/services/voertuig.service';

@Component({
  selector: 'app-voertuig-detail',
  templateUrl: './voertuig-detail.component.html',
  styleUrls: ['./voertuig-detail.component.scss']
})
export class VoertuigDetailComponent implements OnInit {
private route = inject(ActivatedRoute)
private voertuigService = inject(VoertuigService)
wagenTypeEnum = WagenType
brandstofTypeEnum = BrandstofType
voertuig = {} as Voertuig

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.voertuigService.readVoertuigById(params['id']).subscribe(data => {
        this.voertuig = data;
      });
    });
  }
}
