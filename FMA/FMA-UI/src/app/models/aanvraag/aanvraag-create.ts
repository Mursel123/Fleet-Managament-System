import { AanvraagType } from "../enums/aanvraagType";

export interface CreateAanvraag {
    beginPeriode: string;
    eindPeriode: string;
    beschrijving: string;
    voertuigId: string | null;
    aanvraagType: AanvraagType;
}