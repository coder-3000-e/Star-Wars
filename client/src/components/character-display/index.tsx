import React from "react";
import { StarWarsCharacters } from "../../const";
import "./style.css";

interface Props {
    character: StarWarsCharacters | undefined;
}

const CharacterDisplay: React.FC<Props> = ({ character }) => {
    return (
        <div>
            {character && (
                <div>
                    <div className="row">
                        <div style={{height: '11rem'}}><img src={character.image}/></div>
                        <div className="item">{character.name}</div>
                        <div className="item">{character.height}</div>
                        <div className="item">{character.mass}</div>
                        <div className="item">{character.hairColor}</div>
                        <div className="item">{character.skinColor}</div>
                        <div className="item">{character.eyeColor}</div>
                        <div className="item">{character.birthYear}</div>
                        <div className="item">{character.gender}</div>
                        <div className="item">{character.films.length}</div>
                        <div className="item">{character.species.length}</div>
                        <div className="item">{character.vehicles.length}</div>
                        <div className="item">{character.starships.length}</div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default CharacterDisplay;