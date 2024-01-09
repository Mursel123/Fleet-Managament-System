import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { CellClickedEvent, ColDef, GridReadyEvent, ValueFormatterParams } from 'ag-grid-community';
import { Voertuig } from 'src/app/models/voertuig';
import { VoertuigService } from 'src/app/services/voertuig.service';
import { HttpClient } from '@angular/common/http';
import { EnumPipe } from 'src/app/pipes/enum.pipe';
import { WagenType } from 'src/app/models/enums/wagenType';
import { BrandstofType } from 'src/app/models/enums/brandstofType';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-voertuig-table',
  templateUrl: './voertuig-table.component.html',
  styleUrls: ['./voertuig-table.component.scss']
})
export class VoertuigTableComponent {
  router = inject(Router)
  enumPipe = inject(EnumPipe)
  datePipe = inject(DatePipe)
  voertuigService = inject(VoertuigService)
  httpClient = inject(HttpClient)

  public rowData$!: Observable<Voertuig[]>;

  public columnDefs: ColDef[] = [
    { field: 'chassisnummer'},  
    { field: 'startLeasing', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'eersteInschrijving', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'looptijdLeasing', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'wagenType', valueFormatter: (params) => this.enumPipe.transform(params.value, WagenType) },
    { field: 'brandstofType', valueFormatter: (params) => this.enumPipe.transform(params.value, BrandstofType) } 
  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    flex: 1,
    minWidth: 100,
    
  };

  onCellClicked( e: CellClickedEvent): void {
    this.router.navigate(['voertuig-detail/', e.data.id])
  }

  private dateFormatter(params: ValueFormatterParams): string {
    return params.value ? this.datePipe.transform(params.value, 'dd/MM/yyyy') || '' : '';
  }

  onGridReady(params: GridReadyEvent){
    this.rowData$ = this.voertuigService.readVoertuigen();
  }


}
