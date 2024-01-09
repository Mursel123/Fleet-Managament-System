import { Injectable, inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class AlertService {

  private toastr = inject(ToastrService)

  showSuccessCreate(model: string) {
    this.toastr.success(`${model} is succesvol aangemaakt`, 'Succes', {
      positionClass: 'toast-bottom-right'
    });
  }

  showSuccessUpdate(model: string) {
    this.toastr.success(`${model} is succesvol aangepast`, 'Succes', {
      positionClass: 'toast-bottom-right'
    });

  }
  
  showErrorCreate(model: string) {
    this.toastr.error(`Fout bij het aanmaken van een ${model}`, 'Fout', {
      positionClass: 'toast-bottom-right'
    });
  }

  showErrorUpdate(model: string) {
    this.toastr.error(`Fout bij het aanpassen van een ${model}`, 'Fout', {
      positionClass: 'toast-bottom-right'
    });
  }

  showErrorCreateEmpty(model: string) {
    this.toastr.error(model, 'Fout', {
      positionClass: 'toast-bottom-right'
    });
  }

}
