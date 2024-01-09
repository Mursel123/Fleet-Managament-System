import { WagenType } from "../enums/wagenType";
import { BrandstofType } from "../enums/brandstofType";

export interface AanvraagVoertuig {
    id: string
    chassisnummer: string;
    wagenType: WagenType;
    brandstofType: BrandstofType;
}