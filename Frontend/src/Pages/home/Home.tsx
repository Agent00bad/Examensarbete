import { useEffect, useState } from "react";
import AboutModel from "../../Interfaces/models/AboutModel";
import Loading from "../loading/Loading";
import FetchAbout from "../../Ts/FetchAbout";

const Home = () => {

    const [about, setAbout] = useState<AboutModel | undefined>(undefined);

    const date = new Date();

    const calculateAge = (birthDate: Date) : number => {
        let age: number;
        age = date.getFullYear() - birthDate.getFullYear();
        if((date.getMonth() + 1) > birthDate.getMonth()){
            age--;
        }
        else if(date.getMonth() + 1 === birthDate.getMonth() && date.getDate() > birthDate.getDate()){
            age--;
        }
        return age;
    }

    useEffect(() => {
        FetchAbout(1).then(a => setAbout(a));
    }, [])

    if (about != undefined) {
        return (
            <div className="home">
                <div className="image">
                    {about.imageUri != null 
                    ? <img src={about.imageUri} alt={"picture of " + about.firstName + about.lastName} /> 
                    :"" }    
                </div>
                <div className="presentation">
                    <h1>{about.firstName} {about.middleName != null ? about.middleName : ""} {about.lastName}</h1>
                    <div className="details">
                        <h4>Age: {calculateAge(about.birthDate)}</h4>
                        <p>{about.description}</p>
                    </div>
                    <div className="interests-languages">
                    </div>
                </div>
            </div>

        );
    }
    else {
        return (
            <>
                <Loading />
            </>
        )
    }
}

export default Home;