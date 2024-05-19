import AboutModel from "../Interfaces/models/AboutModel";

export default async function FetchAbout(id: number) : Promise<AboutModel> {
 
    //TODO: this is test logic and several things should be changed
    //The url should be in a .ENV file even for testing
    //The user Id should be configured differently
    const res = await fetch("/about?id=" + id) //TODO: localhost might be enough without https extension and look at cors

    let about = await res.json();

    console.log(about);

    return await res.json();
}