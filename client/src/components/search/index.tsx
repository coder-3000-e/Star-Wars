import { StarWarsCharacters } from "../../const";
import CharacterTable from "../characterTable";
import "./style.css";
import React, { useEffect, useState } from "react";

interface Props {
    data: StarWarsCharacters[];
}

const Search: React.FC<Props> = ({ data }) => {
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [searchText, setSearchText] = useState("");
    const [filteredData, setFilteredData] = useState<StarWarsCharacters[]>([]);

    const [isDropdownOpenCharacterB, setIsDropdownOpenCharacterB] = useState(false);
    const [searchTextCharacterB, setSearchTextCharacterB] = useState("");
    const [filteredDataCharacterB, setFilteredDataCharacterB] = useState<StarWarsCharacters[]>([]);

    const [characterA, setCharacterA] = useState<StarWarsCharacters | undefined>();
    const [characterB, setCharacterB] = useState<StarWarsCharacters | undefined>();

    useEffect(() => {
        const filteredCharacterData = data.filter((character) =>
            character.name.toLowerCase().includes(searchText.toLowerCase())
        )
            .filter((character) =>
                characterB ? character.name.toLowerCase() !== characterB.name.toLowerCase() : true
            );;
        setFilteredData(filteredCharacterData);
    }, [characterB, data, searchText]);

    useEffect(() => {
        const filteredCharacterData = data
            .filter((character) =>
                character.name.toLowerCase().includes(searchTextCharacterB.toLowerCase())
            )
            .filter((character) =>
                characterA ? character.name.toLowerCase() !== characterA.name.toLowerCase() : true
            );
        setFilteredDataCharacterB(filteredCharacterData);
    }, [data, searchTextCharacterB, characterA]);


    const toggleDropdown = () => {
        setIsDropdownOpen(!isDropdownOpen);
    };

    const toggleDropdownCharacterB = () => {
        setIsDropdownOpenCharacterB(!isDropdownOpenCharacterB);
    };

    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSearchText(event.target.value);
    };

    return (
        <div>
            <header><h1>Star Wars Character Comparison Tool</h1></header>
            <div className="searchBox">
                <div className="t-dropdown-block">
                    <div className="t-dropdown-select">
                        <input
                            type="text"
                            placeholder="Search"
                            className="t-dropdown-input"
                            value={searchText}
                            onChange={(event) => {
                                setIsDropdownOpen(true);
                                handleSearchChange(event);
                            }}
                        />
                        <span className="t-select-btn" onClick={toggleDropdown}></span>
                    </div>
                    <ul className="t-dropdown-list" style={{ display: isDropdownOpen ? "block" : "none" }}>
                        {filteredData.map((character, index) => (
                            <li className="t-dropdown-item" key={index} onClick={() => {
                                setIsDropdownOpen(false);
                                setSearchText("");
                                setCharacterA(character);
                            }}>
                                {character.name}
                            </li>
                        ))}
                    </ul>
                </div>

                <div className="t-dropdown-block">
                    <div className="t-dropdown-select">
                        <input
                            type="text"
                            placeholder="Search"
                            className="t-dropdown-input"
                            value={searchTextCharacterB}
                            onChange={(event) => {
                                setIsDropdownOpenCharacterB(true);
                                setSearchTextCharacterB(event.target.value);
                            }}
                        />
                        <span className="t-select-btn" onClick={toggleDropdownCharacterB}></span>
                    </div>
                    <ul className="t-dropdown-list" style={{ display: isDropdownOpenCharacterB ? "block" : "none" }}>
                        {filteredDataCharacterB.map((character, index) => (
                            <li className="t-dropdown-item" key={index} onClick={() => {
                                setIsDropdownOpenCharacterB(false);
                                setSearchTextCharacterB("");
                                setCharacterB(character);
                            }}>
                                {character.name}
                            </li>
                        ))}
                    </ul>
                </div>
            </div>
            <CharacterTable characterA={characterA} characterB={characterB} />
        </div>
    );
};

export default Search;
