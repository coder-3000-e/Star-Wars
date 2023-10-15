import axios from 'axios';
import { StarWarsCharacters } from '../const';

export const getCharacters = async (): Promise<StarWarsCharacters[]> => {
  try {
    const response = await axios.get('http://localhost:5000/api/StarWars');

    if (response.status === 200) {
      return response.data as StarWarsCharacters[];
    } else {
      console.error('Unexpected status code:', response.status);
      return [];
    }
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const getCharactersComparison = async (
  firstCharacter: string,
  secondCharacter: string
): Promise<{ [key: string]: string }> => {
  try {
    const response = await axios.get(
      `http://localhost:5000/api/StarWars/CompareCharacters?firstCharacter=${firstCharacter}&secondCharacter=${secondCharacter}`
    );

    if (response.status === 200) {
      return response.data as { [key: string]: string };
    } else {
      console.error('Unexpected status code:', response.status);
      return {};
    }
  } catch (error) {
    console.error('Error fetching data:', error);
    return {};
  }
};
