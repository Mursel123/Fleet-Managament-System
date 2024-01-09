import { DatePipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Aanvraag } from 'src/app/models/aanvraag/aanvraag';
import { AanvraagService } from 'src/app/services/aanvraag.service';
import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, GridReadyEvent, ValueFormatterParams } from 'ag-grid-community';
import { EnumPipe } from 'src/app/pipes/enum.pipe';
import { AanvraagType } from 'src/app/models/enums/aanvraagType';
import { StatusType } from 'src/app/models/enums/statusType';
import { SignalrService } from 'src/app/services/signalr.service';


@Component({
  selector: 'app-aanvraag-admin-table',
  templateUrl: './aanvraag-admin-table.component.html',
  styleUrls: ['./aanvraag-admin-table.component.scss']
})
export class AanvraagAdminTableComponent implements OnInit {

  private datePipe = inject(DatePipe)
  private aanvraagService = inject(AanvraagService)
  private router = inject(Router)
  enumPipe = inject(EnumPipe)
  signalRService = inject(SignalrService)
  public rowData$!: Observable<Aanvraag[]>;
  public rowDataInBehandeling$!: Observable<Aanvraag[]>;

  ngOnInit(): void {
    this.signalRService.getMessageSubject().subscribe(() => {
      this.aanvraagService.readAanvragenNotification()
      .subscribe(() => this.refreshGridData() )
    })
  }
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

  onGridReadyInBehandeling(params: GridReadyEvent){
    this.rowDataInBehandeling$ = this.aanvraagService.readAanvragen(true);
  }
  
  refreshGridData(){
    this.rowData$ = this.aanvraagService.readAanvragen(false);
    this.rowDataInBehandeling$ = this.aanvraagService.readAanvragen(true);
  }
  onGridReady(params: GridReadyEvent){
    this.rowData$ = this.aanvraagService.readAanvragen(false);
  }
}
