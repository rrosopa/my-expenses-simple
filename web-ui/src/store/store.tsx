import { combineReducers, createStore, Store } from 'redux';

// Import reducers and state type
import { characterReducer, ICharacterState } from './character/reducer';
import { ICurrentUserState, currentUserReducer } from './currentUser/reducer';

// Always ask yourself the following:
// 1. Do other parts of the application care about this data?
// 2. Is this data being used to drive multiple components?
// 3. Do you want to cache the data? does the data really required to be cache?
export interface IAppState {
  characterState: ICharacterState;
  currentUserState: ICurrentUserState;
}

// Create the root reducer
const rootReducer = combineReducers<IAppState>({
  characterState: characterReducer,
  currentUserState: currentUserReducer
});

// Create a configure store function of type `IAppState`
export default function configureStore(): Store<IAppState, any> {
  const store = createStore(rootReducer);
  return store;
}