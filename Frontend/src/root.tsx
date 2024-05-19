import { Outlet } from "react-router-dom";
import "./style/root.scss"
import Header from "./Pages/header-footer/Header";
import Footer from "./Pages/header-footer/Footer";

const Root = () => {

    return (
        <div className="root">
            <div className="header-main-relation">
                <header>
                    <Header />
                </header>
                <main>
                    <Outlet />
                </main>
            </div>
                <footer>
                    <Footer />
                </footer>
        </div>
    );
}

export default Root;