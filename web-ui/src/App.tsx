import React, { Component } from 'react';
import DashboardPage from './pages/dashboard/dashboard';
import NotFoundPage from './pages/errors/notFound';
import ForbiddenPage from './pages/errors/forbidden';
import {
	BrowserRouter as Router, 
	Route,
	Redirect,
	Switch
} from 'react-router-dom';
import SecuredRoute from './components/securedRoute';

class App extends Component {
	render() {
		return (
			<div className="App w-100 h-100 d-flex">
				<div className="d-none d-lg-flex flex-column w-25 pt-5 pb-5 border">
					<ul className="nav flex-column">
						<li className="nav-item">
							<a className="nav-link active" aria-current="page" href="#">Link 1</a>
						</li>
						<li className="nav-item">
							<a className="nav-link" href="#">Link 2</a>
						</li>
						<li className="nav-item">
							<a className="nav-link" href="#">Link 3</a>
						</li>
						<li className="nav-item">
							<a className="nav-link" href="#">Link 4</a>
						</li>
						<li className="nav-item">
							<a className="nav-link" href="#">Link 5</a>
						</li>
					</ul>
				</div>
				<div className="w-100 w-lg-75 bg-light bg-gradient pt-5 pb-5">
					<Router>
						<Switch>
							<Route exact path="/" component={DashboardPage} />
							<Route exact path="/dashboard" component={DashboardPage} />
							<Route exact path="/not-found" component={NotFoundPage} />
							{/* <Route exact path="/fobidden" component={ForbiddenPage} /> */}
							{/* <SecuredRoute exact={true} path="/" component={HomePage} /> */}
							<Redirect to="/not-found" />
						</Switch>
					</Router>
				</div>
			</div>
		);
	}
}

export default App;
