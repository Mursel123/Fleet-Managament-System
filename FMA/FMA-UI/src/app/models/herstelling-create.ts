import { Document } from "./document"

export interface CreateHerstelling {
    datumUitvoering: string;
    kostprijs: number;
    aanvraagId: string;
    voertuigId: string;
    verzekeringsmaatschappijId: string;
    gemeldeSchadeId: string | null;
    documenten: Document[];
}