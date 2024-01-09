import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { ChauffeurList } from '../models/chauffeur-list';
import { Observable, throwError, of  } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Chauffeur } from '../models/chauffeur';
import { catchError } from 'rxjs/operators';
import { CreateChauffeur } from '../models/chauffeur-create';
import { UpdateChauffeur } from '../models/chauffeur-update';
import { AuthService } from './auth.service';



@Injectable({
  providedIn: 'root'
})
export class ChauffeurService {


  constructor(private http: HttpClient, private authService: AuthService) {
   }

  httpOptions = {
    headers: new HttpHeaders(
      { 
        'Content-Type': 'application/json', 
        'Access-Control-Allow-Origin': `${environment.clientRoot}`
      }
    )
  };
  

  readChauffeursList() : Observable<ChauffeurList[]>{
    return this.http.get<ChauffeurList[]>(`${environment.readApiUrl}/Chauffeur/all`)
    }
    
  readChauffeurById(id: string) : Observable<Chauffeur>{
    return this.http.get<Chauffeur>(`${environment.readApiUrl}/Chauffeur/${id}`)
  }

  readChauffeurByEmail() : Observable<Chauffeur>{
    return this.http.get<Chauffeur>(`${environment.readApiUrl}/Chauffeur/email`)
  }

  createChauffeur(chauffeur: CreateChauffeur) : Observable<string>{
     return this.http.post<string>(`${environment.writeApiUrl}/chauffeur`, chauffeur)
  }
  activeChauffeur(active: boolean, id: String): Observable<string>{
    return this.http.patch<string>(`${environment.writeApiUrl}/Chauffeur?active=${active}&id=${id}`, this.httpOptions)
  }
  updateChauffeur(chauffeur: UpdateChauffeur){
    this.http.put<UpdateChauffeur>(`${environment.writeApiUrl}/Chauffeur`, chauffeur, this.httpOptions).subscribe()
  }

}
