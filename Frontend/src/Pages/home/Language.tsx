import LanguageModel from "../../Interfaces/models/LangaugeModel"
import "../../style/language.scss"

interface ILanguage{
    language : LanguageModel;
}

const Language = ({language} : ILanguage) => {
    return(
        <div className="language">
            <p>{language.name}</p>
            <p>{language.level}</p> 
        </div>
    )
}

export default Language;