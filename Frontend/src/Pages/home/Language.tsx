import LanguageModel from "../../Interfaces/models/LangaugeModel"

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