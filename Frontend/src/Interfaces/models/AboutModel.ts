export default interface AboutModel {
    Id: number;
    FirstName: string;
    LastName: string;
    MiddleName?: string;
    BirthDate: Date;
    Description?: string;
    ImageUri?: string; 
    Languages?: Array<LanguageModel>;
    Interests?: Array<InterestModel>;
}

interface LanguageModel {
    Id: string;
    Name: string;
    Level?: LanguageLevel;
}
interface InterestModel{
    Id: string;
    Name: string;
    Description?: string;
}
enum LanguageLevel{
    Beginner,
    Intermediate,
    Professional,
    Fluent,
    Native
}