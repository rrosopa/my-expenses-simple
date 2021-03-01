import React, { Component } from 'react';

interface IForbiddenPageProps { }
interface IForbiddenPageState { }

class ForbiddenPage extends Component<IForbiddenPageProps, IForbiddenPageState> {
    constructor(props: IForbiddenPageProps){
        super(props);
        
        this.state = { };
    }
    
    componentDidMount() { }

    render() {
		return (
			<div>
                <p>Page not found</p>
			</div>
		);
	}
}

export default ForbiddenPage;
