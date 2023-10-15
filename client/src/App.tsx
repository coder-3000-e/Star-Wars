import React, { useEffect, useState } from 'react';
import './App.css';
import { StarWarsCharacters } from './const';
import { getCharacters } from './axios';
import Search from './components/search';
import Loading from './components/loading';

function App() {
  const [StarWarsCharactersData, SetStarWarsCharactersData] = useState<StarWarsCharacters[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getCharacters();
        SetStarWarsCharactersData(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  return (
    StarWarsCharactersData.length === 0 ? (
      <Loading />
    ) : (
      <div className="App">
        <Search data={StarWarsCharactersData} />
      </div>
    )
  );
}

export default App;
