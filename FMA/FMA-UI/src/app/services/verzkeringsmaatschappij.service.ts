import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { VerzekeringsmaatschappijSelectList } from '../models/verzekeringsmaatschappij-selectlist';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VerzekeringsmaatschappijService {

  private http = inject(HttpClient)

  readVerzekeringsmaatschappijenSelectList() : Observable<VerzekeringsmaatschappijSelectList[]>{
    return this.http.get<VerzekeringsmaatschappijSelectList[]>(`${environment.readApiUrl}/Verzekeringsmaatschappij/all/selectlist`)
    }
}
