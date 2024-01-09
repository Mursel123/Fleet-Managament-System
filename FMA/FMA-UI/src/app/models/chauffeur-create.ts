import { RijbewijsType } from "./enums/rijbewijsType";
import { Geslacht } from "./enums/geslacht";

export interface CreateChauffeur {
    naam: string;
    voornaam: string;
    email: string;
    geboortedatum: string;
    rijksregisternummer: string;
    isActief: boolean;
    adresId: string | null;
    tankkaartId: string | null;
    straat: string;
    nummer: string;
    bus: string;
    postcode: string;
    stad: string;
    rijbewijsType: RijbewijsType | null;
    geslacht: Geslacht;
}