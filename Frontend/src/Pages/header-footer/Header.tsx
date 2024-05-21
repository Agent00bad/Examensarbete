import "../../style/header.scss"
import NavObject from "../../Interfaces/NavigationObject"
import { NavLink } from "react-router-dom";
const Header = () => {


    const links: Array<NavObject> = [
        { Path: "/", Name: "Home" },
        { Path: "/experience", Name: "Experience" },
        { Path: "/education", Name: "Education" },
        { Path: "/projects", Name: "Projects" },
        { Path: "/About", Name: "About" }
    ]

    return (
        <div className="header">
            <nav className="navbar">
                <div className="nav-div">
                    <ul className="nav-links">
                        {links.map((nav, index) => {
                            return (
                                <NavLink to={nav.Path}>
                                    <li className={"link link-" + { index }} key={index}>
                                        {nav.Icon != undefined
                                            ? nav.Icon.ExternalUri
                                                // TODO: better implementation of external icon
                                                ? nav.Icon.Uri
                                                : <img src={nav.Icon.Uri} alt={nav.Name + " icon"} />
                                            : ""}{nav.Name}
                                    </li>
                                </NavLink>
                            )
                        })}
                    </ul>
                </div>
            </nav>
        </div>
    );
};

export default Header;