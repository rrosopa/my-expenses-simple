
import { Component } from "react";


interface IProps extends React.DetailedHTMLProps<React.HTMLAttributes<HTMLDivElement>, HTMLDivElement> { }

export default class MetadataInputContainer extends Component<IProps> {    
    render() {
		return (
			<div className="metadata-input-container" {...this.props}>
                {this.props.children}
			</div>
		);
	}
}