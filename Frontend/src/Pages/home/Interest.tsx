import InterestModel from "../../Interfaces/models/InterestModel";
import "../../style/languageInterest.scss"

interface IInterest {
    interest : InterestModel
}

const Interest = ({interest} : IInterest) => {
    return(
        <div className="interest">
            <p>{interest.name}</p>
        </div>
    )
}

export default Interest;