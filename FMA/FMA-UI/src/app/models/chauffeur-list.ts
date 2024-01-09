
import { Adres } from "./adres";
import { Gemeente } from "./gemeente";

export interface ChauffeurList {
    id: string;
    naam: string;
    voornaam: string;
    email: string;
    geboortedatum: string;
    rijksregisternummer: string;
    adres: Adres;
    gemeente: Gemeente | null;
    isActief: boolean;
}