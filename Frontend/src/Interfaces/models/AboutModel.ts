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

interface LanguageModel {
    id: string;
    name: string;
    level?: LanguageLevel;
}
interface InterestModel{
    id: string;
    name: string;
    description?: string;
}
enum LanguageLevel{
    Beginner,
    Intermediate,
    Professional,
    Fluent,
    Native
}