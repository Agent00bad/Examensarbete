import InterestModel from "./InterestModel";
import LanguageModel from "./LangaugeModel";

export default interface AboutModel {
    id: number;
    firstName: string;
    lastName: string;
    middleName?: string;
    birthDate: Date;
    description?: string;
    imageUri?: string; 
    languages?: Array<LanguageModel>;
    interests?: Array<InterestModel>;
}
