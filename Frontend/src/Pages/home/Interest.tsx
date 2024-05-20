import InterestModel from "../../Interfaces/models/InterestModel";

interface IInterest {
    interest : InterestModel
}

const Interest = ({interest} : IInterest) => {
    return(
        <div className="interst">
            <p>{interest.name}</p>
        </div>
    )
}

export default Interest;