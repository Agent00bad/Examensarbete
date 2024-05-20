import "../../style/header.scss"
import NavObject from "../../Interfaces/NavigationObject"

const Header = () => {


    const links : Array<NavObject> = [
        {Path : "/", Name: "Home"}, 
        {Path : "/experience", Name: "Experience"},
        {Path : "/education", Name: "Education"},
        {Path : "/projects", Name: "Projects"},
        {Path : "/About", Name: "About"}
    ]

    return(
        <div className="header">
            <nav className="navbar">
                <div className="nav-div">
                    <ul className="nav-links">
                        {links.map((nav, index) => {return(
                            <li className={"link link-" + {index}} key={index}>
                                <a href={nav.Path}>{nav.Icon != undefined 
                                ? nav.Icon.ExternalUri
                                // TODO: better implementation of external icon
                                ? nav.Icon.Uri 
                                : <img src={nav.Icon.Uri} alt={nav.Name + " icon"}/>
                                : ""}{nav.Name}</a>
                            </li>
                        )})}
                    </ul>
                </div>
            </nav>
        </div>
    );
};

export default Header;