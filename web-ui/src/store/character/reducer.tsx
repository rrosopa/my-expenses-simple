// Import Reducer type
import { Reducer } from 'redux';
import { CharacterActions, CharacterActionTypes } from './actions';
import { ICharacter } from '../../models/characters/ICharacter';

// Define the Character State
export interface ICharacterState {
  readonly characters: ICharacter[];
}

// Define the initial state
const initialCharacterState: ICharacterState = {
  characters: [],
};

export const characterReducer: Reducer<ICharacterState, CharacterActions> = (
  state = initialCharacterState,
  action
) => {
  switch (action.type) {
    case CharacterActionTypes.ADD: {
      return {
        ...state,
        characters: [...state.characters, action.character],
      };
    }
    case CharacterActionTypes.GET_ALL: {
      return {
        ...state,
        characters: action.characters,
      };
    }
    default:
      return state;
  }
};