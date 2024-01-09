import { Injectable, inject } from '@angular/core';
import { CreateOnderhoud } from '../models/onderhoud-create';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OnderhoudService {

  constructor() { }
  private http = inject(HttpClient)

  createOnderhoud(onderhoud: CreateOnderhoud) {
    this.http.post<CreateOnderhoud>(`${environment.writeApiUrl}/Onderhoud`, onderhoud).subscribe()
  }
}
