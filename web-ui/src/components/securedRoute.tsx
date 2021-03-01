import React, { Component } from 'react';
import { Route, Redirect, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { IAppState } from '../store/store';
import { ICurrentUserDetails } from '../models/users/CurrentUserDetails';

interface ISecuredRouteProps {
    path: string;
    component: React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;
    exact?: boolean;
    
    titleRequirements?: string[];
    currentUser: ICurrentUserDetails;
}

class SecuredRoute extends Component<ISecuredRouteProps> {
    constructor(props: ISecuredRouteProps){
        super(props);
        
        this.state = {};
    }

    private isLoggedIn(): boolean {
        return localStorage.getItem("authToken") ? true : false;
    }

    private isTitleRequirementsMet(): boolean {
        if(this.props.titleRequirements === null || this.props.titleRequirements === undefined)
            return true;
        
        if(this.props.titleRequirements.length === 0)
            return true;

        return this.props.titleRequirements.findIndex(titles => titles === this.props.currentUser.title) > -1
    }

    render() {
        return <> 
            {
                this.isLoggedIn() && this.isTitleRequirementsMet() 
                    ? <Route path={this.props.path} exact={this.props.exact} component={this.props.component} /> 
                    : <Redirect to='login' />
            } 
        </>
	}
}

const mapStateToProps = (store: IAppState) => {
	return {
		currentUser: store.currentUserState.currentUser
	};
}

export default connect(mapStateToProps)(SecuredRoute);
