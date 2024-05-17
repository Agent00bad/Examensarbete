
export default interface NavObject 
{
    Path: string;
    Name: string;
    Icon?: NavIconUri;
}

interface NavIconUri{
    Uri: string;
    ExternalUri: boolean;
}