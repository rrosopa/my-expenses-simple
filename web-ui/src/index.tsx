import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

/* Make the store available to all container 
components in the application without passing it explicitly */
import { Provider } from 'react-redux';

// Store type from Redux
import { Store } from 'redux';

// Import the store function and state
import configureStore, { IAppState } from './store/store';
// import { getAllCharacters } from './store/character/actions';

interface IProps {
  store: Store<IAppState>;
}

/* 
Create a root component that receives the store via props
and wraps the App component with Provider, giving props to containers
*/
const Root: React.SFC<IProps> = props => {
  return (
    <Provider store={props.store}>
      <App />
    </Provider>
  );
};

// Generate the store
const store = configureStore();
// store.dispatch(getAllCharacters());


ReactDOM.render(<Root store={store} />, document.getElementById(
  'root'
) as HTMLElement);
