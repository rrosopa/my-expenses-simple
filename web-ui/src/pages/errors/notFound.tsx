import React, { Component } from 'react';

interface INotFoundPageProps { }
interface INotFoundPageState { }

class NotFoundPage extends Component<INotFoundPageProps, INotFoundPageState> {
    constructor(props: INotFoundPageProps){
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

export default NotFoundPage;
