import { AanvraagChauffeur } from "./aanvraag-chauffeur";
import { AanvraagVoertuig } from "./aanvraag-voertuig";
import { AanvraagType } from "../enums/aanvraagType";
import { StatusType } from "../enums/statusType";
import { AanvraagHerstelling } from "./aanvraag-herstelling";
import { AanvraagOnderhoud } from "./aanvraag-onderhoud";

export interface Aanvraag {
    id: string;
    datumAanvraag: string;
    beginPeriode: string;
    eindPeriode: string;
    beschrijving: string;
    onderhoud: AanvraagOnderhoud
    herstelling: AanvraagHerstelling
    chauffeur: AanvraagChauffeur;
    voertuig: AanvraagVoertuig | null;
    aanvraagType: AanvraagType;
    statusType: StatusType;
}