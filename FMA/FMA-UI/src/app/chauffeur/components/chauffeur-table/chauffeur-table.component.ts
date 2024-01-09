import { Component, OnInit, inject} from '@angular/core';
import { ChauffeurList } from 'src/app/models/chauffeur-list';
import { AuthService } from 'src/app/services/auth.service';
import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, GridReadyEvent, ValueFormatterParams } from 'ag-grid-community';
import { ChauffeurService } from 'src/app/services/chauffeur.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-chauffeur-table',
  templateUrl: './chauffeur-table.component.html',
  styleUrls: ['./chauffeur-table.component.scss']
})
export class ChauffeurTableComponent{
  // injects
  private datePipe = inject(DatePipe)
  private chauffeurService = inject(ChauffeurService)
  private router = inject(Router)
  public rowData$!: Observable<ChauffeurList[]>;

  public columnDefs: ColDef[] = [
    { field: 'naam'},
    { field: 'voornaam' },
    { field: 'email' },
    { field: 'geboortedatum', valueFormatter: this.dateFormatter.bind(this) },
    { field: 'rijksregisternummer' },
    { field: 'adres.straat', headerName: 'Straat' },
    { field: 'gemeente.postcode', headerName: 'Postcode' },
    { field: 'isActief' , headerName: 'Actief', filterParams: { values: ['true'] }}
  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    flex: 1,
    minWidth: 100,
  };

  private dateFormatter(params: ValueFormatterParams): string {
    return params.value ? this.datePipe.transform(params.value, 'dd/MM/yyyy') || '' : '';
  }

  onCellClicked( e: CellClickedEvent): void {
    const rowData = e.data;
    const id = rowData.id
    this.router.navigate(['chauffeur-detail/', id])
  }

  onGridReady(params: GridReadyEvent){
    this.rowData$ = this.chauffeurService.readChauffeursList();
  }
  
}
