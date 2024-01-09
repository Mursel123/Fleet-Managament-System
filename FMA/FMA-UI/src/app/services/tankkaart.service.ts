import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { TankkaartSelectList } from '../models/tankkaart-selectlist';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TankkaartService {

  constructor(private http: HttpClient) { }

  readTankkaartenSelectList() : Observable<TankkaartSelectList[]>{
    return this.http.get<TankkaartSelectList[]>(`${environment.readApiUrl}/Tankkaart/all/selectlist`)
    }
}
