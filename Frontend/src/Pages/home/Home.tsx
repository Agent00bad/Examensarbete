import { useEffect } from "react";
import { useState } from "react";
import FetchAbout from "../../Ts/FetchAbout";
import AboutModel from "../../Interfaces/models/AboutModel";
import Loading from "../loading/Loading";

const Home = () => {

    const [about, setAbout] = useState<AboutModel | undefined>(undefined);
    useEffect(() => {
        FetchAbout(1).then();
    },[])
        if(about != undefined){
            return (
                <div className="home">
                </div>
            );
        }
        else {
            return(
                <>
                <Loading/>
                </>
            )
        }
}

export default Home;