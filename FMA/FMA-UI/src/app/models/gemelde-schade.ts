import { ChauffeurVoertuig } from "./chauffeur-voertuig";


export interface GemeldeSchade {
    id: string;
    datumMelding: string;
    datumSchade: string;
    schade: string;
    voertuig: ChauffeurVoertuig;

}