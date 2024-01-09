import { WagenType } from "./enums/wagenType";
import { BrandstofType } from "./enums/brandstofType";

export interface Voertuig {
    id: string;
    chassisnummer: string;
    startLeasing: string;
    eersteInschrijving: string;
    looptijdLeasing: string;
    wagenType: WagenType | null;
    brandstofType: BrandstofType;
}