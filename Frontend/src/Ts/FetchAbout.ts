import AboutModel from "../Interfaces/models/AboutModel";

export default async function FetchAbout(id: number) : Promise<AboutModel> {
 
    //TODO: this is test logic and several things should be changed
    //The url should be in a .ENV file even for testing
    //The user Id should be configured differently
    const response = await fetch("/api/about?id=" + id, 
    {
        method: "GET",
        headers: {
          "Accept": "application/json"  
        }
      }
    ); //Make it compatible for prod later
    
    let about = await response.json();

    return about; 
}