
import React, { Component } from "react";
import { MetadataControlType } from "./metadataControl";
import MetadataInput, { IMetadataInput } from "./metadataInput";
import MetadataSelect, { IMetadataSelect } from "./metadataSelect";


export interface IMetadataForm {
    formdId: string;

    metadata: Array<IMetadataInput|IMetadataSelect>;

    onSubmit?: () => void;
    onCancel?: () => void;
}

class MetadataForm extends Component<IMetadataForm> {

    renderControls(){
        if(this.props.metadata?.length > 0)
            return this.props.metadata.map((m, i) => {
                if(m.controlType === MetadataControlType.Input)
                    return <MetadataInput {...(m as IMetadataInput)} key={i}/>
                else if(m.controlType === MetadataControlType.Select)
                    return <MetadataSelect {...(m as IMetadataSelect)} key={i} />
            });
    }

    render() {
		return (
			<div>
                <form id={this.props.formdId} className="metadata-form">
                    { this.renderControls() }
                </form>
			</div>
		);
	}
}

export default MetadataForm;