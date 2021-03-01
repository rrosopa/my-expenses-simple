
import React, { ChangeEvent, Component } from "react";
import IMetadataControl from "./metadataControl";
import MetadataInputContainer from "./metadataInputContainer";


export interface IMetadataInput extends IMetadataControl {    
    maxLength?: number;
    maxValue?: number;
    minLength?: number;
    minValue?: number;
    type?: string;
    
    onChange?: (e: ChangeEvent<HTMLInputElement>) => void;
}

class MetadataInput extends Component<IMetadataInput> {
    render() {
        console.log(this.props);

		return (
			<MetadataInputContainer>
                <label>{this.props.label}</label>
                <input 
                    id={this.props.id}
                    value={this.props.onChange ? this.props.value : undefined}
                    defaultValue={this.props.onChange ? undefined : this.props.value}


                    disabled={this.props.disabled}
                    max={this.props.maxValue}
                    maxLength={this.props.maxLength}
                    minLength={this.props.minLength}
                    min={this.props.minValue}
                    name={this.props.name}
                    required={this.props.required}
                    type={this.props.type}


                    onChange={this.props.onChange}
                    style={{display: this.props.hidden === true ? 'none' : 'inherit'}}

                    className="metadata-input"
                />              
            </MetadataInputContainer>
		);
	}
}

export default MetadataInput;