import { ICurrentUserDetails } from '../../models/users/CurrentUserDetails';

// Create Action Constants
export enum CurrentUserActionTypes {
	SET_CURRENT_USER = 'SET_CURRENT_USER'
}

// Interface for Get All Action Type
export interface ICurrentUserSetAction {
	type: CurrentUserActionTypes.SET_CURRENT_USER;
	currentUser: ICurrentUserDetails;
}

export type CurrentUserActions = ICurrentUserSetAction

export function setCurrentUser(currentUser: ICurrentUserDetails): ICurrentUserSetAction {
	return {
		type: CurrentUserActionTypes.SET_CURRENT_USER,
		currentUser: currentUser
	}
}