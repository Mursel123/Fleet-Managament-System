import { RijbewijsType } from "./enums/rijbewijsType";

export interface UpdateChauffeur{
    id: string;
    naam: string;
    voornaam: string;
    email: string;
    isActief: boolean;
    gemeenteId: string;
    tankkaartId: string | null;
    straat: string;
    nummer: string;
    bus: string;
    postcode: string;
    stad: string;
    rijbewijsType: RijbewijsType | null;
}