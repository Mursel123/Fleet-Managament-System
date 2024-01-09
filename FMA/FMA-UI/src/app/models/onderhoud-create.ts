import { BestandType } from "./enums/bestandType";

export interface CreateOnderhoud {
    datumUitvoering: string;
    kostprijs: number;
    uitgevoerdeWerken: string;
    fileName: string;
    fileData: string;
    bestandType: BestandType;
    aanvraagId: string;
    voertuigId: string;
    garageId: string | null;
}