
import "./overlay.scss";
import { Component } from "react";


class Overlay extends Component {
    render() {
		return (
			<div className="overlay">
                {this.props.children}
			</div>
		);
	}
}

export default Overlay;