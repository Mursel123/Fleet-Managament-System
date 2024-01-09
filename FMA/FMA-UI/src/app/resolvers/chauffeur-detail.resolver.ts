import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { ChauffeurService } from '../services/chauffeur.service';
import { Chauffeur } from '../models/chauffeur';

export const chauffeurDetailResolver: ResolveFn<Chauffeur> = (route, state, chauffeurService = inject(ChauffeurService)) => {
  
  const id = route.params['id'];

  if (id) {
    return chauffeurService.readChauffeurById(id);
  } else {

    return chauffeurService.readChauffeurByEmail();
  }

};
