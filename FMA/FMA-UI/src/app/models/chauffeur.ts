import { ChauffeurTankkaart} from "./chauffeur-tankkaart";
import { Adres } from "./adres";
import { Geslacht } from "./enums/geslacht";
import { RijbewijsType } from "./enums/rijbewijsType";
import { GemeldeSchade } from "./gemelde-schade";
import { Gemeente } from "./gemeente";

export interface Chauffeur {
    id: string;
    naam: string;
    voornaam: string;
    email: string;
    geboortedatum: string;
    rijksregisternummer: string;
    isActief: boolean;
    tankkaart: ChauffeurTankkaart | null;
    adres: Adres;
    gemeente: Gemeente | null;
    geslacht: Geslacht;
    rijbewijsType: RijbewijsType | null;
    gemeldeSchades: GemeldeSchade[];
}