import { DatePipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Aanvraag } from 'src/app/models/aanvraag/aanvraag';
import { EnumPipe } from 'src/app/pipes/enum.pipe';
import { AanvraagService } from 'src/app/services/aanvraag.service';
import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, GridReadyEvent, ValueFormatterParams } from 'ag-grid-community';
import { AanvraagType } from 'src/app/models/enums/aanvraagType';
import { StatusType } from 'src/app/models/enums/statusType';

@Component({
  selector: 'app-aanvraag-chauffeur',
  templateUrl: './aanvraag-chauffeur.component.html',
  styleUrls: ['./aanvraag-chauffeur.component.scss']
})
export class AanvraagChauffeurComponent {
  private datePipe = inject(DatePipe)
  private aanvraagService = inject(AanvraagService)
  private router = inject(Router)
  enumPipe = inject(EnumPipe)

  public rowData$!: Observable<Aanvraag[]>;

  public columnDefs: ColDef[] = [
    { field: 'datumAanvraag', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'beginPeriode', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'eindPeriode', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'beschrijving' },
    { field: 'chauffeur.email', headerName: 'Chauffeur' },
    { field: 'voertuig.chassisnummer', headerName: 'Voertuig' },
    { field: 'aanvraagType', valueFormatter: (params) => this.enumPipe.transform(params.value, AanvraagType)},
    { field: 'statusType', valueFormatter: (params) => this.enumPipe.transform(params.value, StatusType)}
  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    flex: 1,
    minWidth: 50,
    
  };

  private dateFormatter(params: ValueFormatterParams): string {
    return params.value ? this.datePipe.transform(params.value, 'dd/MM/yyyy') || '' : '';
  }

  onCellClicked( e: CellClickedEvent): void {
    this.router.navigate(['aanvragen/', e.data.id])
  }

  onGridReady(params: GridReadyEvent){
    this.rowData$ = this.aanvraagService.readAanvragenByEmail();
  }
}
