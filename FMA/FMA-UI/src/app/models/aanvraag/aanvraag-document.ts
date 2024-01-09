import { BestandType } from "../enums/bestandType";

export interface AanvraagDocument {
    fileData: string;
    fileName: string;
    bestandType: BestandType;
}