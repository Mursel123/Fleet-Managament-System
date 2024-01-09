import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'

import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Aanvraag } from '../models/aanvraag/aanvraag';
import { StatusType } from '../models/enums/statusType';
import { CreateAanvraag } from '../models/aanvraag/aanvraag-create';
import { AanvraagNotification } from '../models/aanvraag/aanvraag-notification';

@Injectable({
  providedIn: 'root'
})
export class AanvraagService {

  constructor(private http: HttpClient) { }

  readAanvragen(inBehandeling: boolean) : Observable<Aanvraag[]>{
    return this.http.get<Aanvraag[]>(`${environment.readApiUrl}/aanvraag/in_behandeling=${inBehandeling}/all`)
    }

  readAanvragenByEmail() : Observable<Aanvraag[]>{
    return this.http.get<Aanvraag[]>(`${environment.readApiUrl}/aanvraag/email/all`)
    }

    readAanvragenNotification() : Observable<AanvraagNotification[]>{
      return this.http.get<AanvraagNotification[]>(`${environment.readApiUrl}/aanvraag/notification/all`)
      }

    readAanvragenInBehandelingCount() : Observable<number>{
      return this.http.get<number>(`${environment.readApiUrl}/aanvraag/in_behandeling/count`)
      }

      readAanvraagById(id: string) : Observable<Aanvraag>{
        return this.http.get<Aanvraag>(`${environment.readApiUrl}/aanvraag/${id}`)
        }
  
  updateAanvraagStatus(statusType: StatusType, id: string){
    
    this.http.patch(`${environment.writeApiUrl}/aanvraag/status`,  {Id:id, StatusType:statusType}).subscribe()
  }
createAanvraag(aanvraag: CreateAanvraag): Observable<string> {
    return this.http.post<string>(`${environment.writeApiUrl}/aanvraag`, aanvraag) // Extract the ID string from the response
  }
}
