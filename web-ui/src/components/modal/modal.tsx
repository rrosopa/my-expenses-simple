import "./modal.scss";
import React, { Component } from 'react';
import Overlay from '../overlay/overlay';

interface IModalProps {
}

class Modal extends Component<IModalProps> {
    render() {
		return (
			<Overlay>
                <div className="modal-container">
                    <div>
                        {this.props.children}
                    </div>
                </div>
            </Overlay>
		);
	}
}

export default (Modal);
