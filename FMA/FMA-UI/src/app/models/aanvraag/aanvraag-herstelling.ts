import { AanvraagVerzekeringsmaatschappij } from "./aanvraag-verzekeringsmaatschappij"
import { AanvraagGemeldeSchade } from "./aanvraag-gemeldeSchade";
import { AanvraagDocument } from "./aanvraag-document";

export interface AanvraagHerstelling {
    datumUitvoering: string;
    kostprijs: number;
    verzekeringsmaatschappij: AanvraagVerzekeringsmaatschappij;
    gemeldeSchade: AanvraagGemeldeSchade | null;
    documenten: AanvraagDocument[];
}