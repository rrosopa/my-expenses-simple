import { ActionCreator, Dispatch } from 'redux';
import axios from 'axios';

import { ICharacterState } from './reducer';
import { ICharacter } from '../../models/characters/ICharacter';

// Create Action Constants
export enum CharacterActionTypes {
	ADD = 'ADD',
	GET_ALL = 'GET_ALL',
}

// Interface for Get All Action Type
export interface ICharacterGetAllAction {
	type: CharacterActionTypes.GET_ALL;
	characters: ICharacter[];
}

export interface IAddCharacterAction {
	type: CharacterActionTypes.ADD;
	character: ICharacter;
}

/* 
Combine the action types with a union (we assume there are more)
example: export type CharacterActions = IGetAllAction | IGetOneAction ... 
*/
export type CharacterActions = ICharacterGetAllAction | IAddCharacterAction;

/* Get All Action
<Promise<Return Type>, State Interface, Type of Param, Type of Action> */
export function addCharacter(name: string): IAddCharacterAction {
	return {
		type: CharacterActionTypes.ADD,
		character: {
			name: name
		}
	}
}