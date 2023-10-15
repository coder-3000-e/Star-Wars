import { StarWarsCharacters } from "../../const";
import CharacterDisplay from "../character-display";
import Comparison from "../comparison";
import "./style.css";
import React from "react";

interface Props {
    characterA: StarWarsCharacters | undefined;
    characterB: StarWarsCharacters | undefined;
}

const CharacterTable: React.FC<Props> = ({ characterA, characterB }) => {
    return (
        <div className="characterTable-box">
            <div style={{ display: 'flex', flexDirection: 'row' }}>
                <aside>
                    <div className="row">
                        <div style={{ height: '11rem' }}></div>
                        <div className="item">Name</div>
                        <div className="item">Height</div>
                        <div className="item">Mass</div>
                        <div className="item">HairColor</div>
                        <div className="item">SkinColor</div>
                        <div className="item">EyeColor</div>
                        <div className="item">BirthYear</div>
                        <div className="item">Gender</div>
                        <div className="item">Films</div>
                        <div className="item">Species</div>
                        <div className="item">Vehicles</div>
                        <div className="item">Starships</div>
                    </div>
                </aside>
                <section><CharacterDisplay character={characterA} /></section>
                <section><CharacterDisplay character={characterB} /></section>
            </div>
            {
                characterA && characterB && (
                    <Comparison characterA={characterA} characterB={characterB} />
                )
            }
        </div>
    );
};

export default CharacterTable;
