// Import Reducer type
import { Reducer } from 'redux';
import { CurrentUserActions, CurrentUserActionTypes } from './actions';
import { ICurrentUserDetails, CurrentUserDetails } from '../../models/users/CurrentUserDetails';

export interface ICurrentUserState {
    readonly currentUser: ICurrentUserDetails;
}

// Define the initial state
const initialCurrentUserState: ICurrentUserState = {
    currentUser: new CurrentUserDetails(),
};

export const currentUserReducer: Reducer<ICurrentUserState, CurrentUserActions> = (
    state = initialCurrentUserState,
    action
) => {
    switch (action.type) {
        case CurrentUserActionTypes.SET_CURRENT_USER: {
            return {
                ...state,
                currentUser: action.currentUser,
            };
        }
        default:
            return state;
    }
};