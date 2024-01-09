import { AanvraagType } from "../enums/aanvraagType";
import { AanvraagVoertuig } from "./aanvraag-voertuig";

export interface AanvraagNotification 
{
    id: string;
    beschrijving: string;
    aanvraagType: AanvraagType;
    voertuig: AanvraagVoertuig
}