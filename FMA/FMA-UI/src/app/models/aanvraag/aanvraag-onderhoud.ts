import { AanvraagDocument } from "./aanvraag-document";

export interface AanvraagOnderhoud {
    datumUitvoering: string;
    kostprijs: number;
    uitgevoerdeWerken: string;
    document: AanvraagDocument;
}