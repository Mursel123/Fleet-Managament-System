import { BestandType } from "./enums/bestandType"; 

export interface Document {
    fileData: string;
    fileName: string;
    bestandType: BestandType;
}