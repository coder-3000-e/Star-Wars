import { getCharactersComparison } from "../../axios";
import { StarWarsCharacters } from "../../const";
import "./style.css";
import React, { useEffect, useState } from "react";

interface Props {
    characterA: StarWarsCharacters;
    characterB: StarWarsCharacters;
}

const Comparison: React.FC<Props> = ({ characterA, characterB }) => {
    const [comparisonData, setComparisonData] = useState<{
        [key: string]: string;
    }>();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getCharactersComparison(characterA.name, characterB.name);
                setComparisonData(data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [characterA.name, characterB.name]);

    return (
        <div className="comparison-data">
            <h2>Comparison Results:</h2>
            <ul>
                {comparisonData && Object.entries(comparisonData).map(([key, value]) => (
                    <div key={key}>
                        <strong>{key}:</strong> {value}
                    </div>
                ))}
            </ul>
        </div>
    );
};

export default Comparison;
