
import React, { ChangeEvent, Component } from "react";
import { IKeyValuePair } from "../../models/common/iKeyValuePair";
import IMetadataControl from "./metadataControl";
import MetadataInputContainer from "./metadataInputContainer";


export interface IMetadataSelect extends IMetadataControl {   
    options: IKeyValuePair<string|number, string|number>[];
    onChange?: (e: ChangeEvent<HTMLSelectElement>) => void;
}

class MetadataSelect extends Component<IMetadataSelect> {

    renderOptions(){
        if(this.props.options?.length > 0){
            var keys: any[] = [];
            return this.props.options.map((o, i) => {
                
                if(keys.indexOf(o.key) !== -1)
                    console.warn(`Key '${o.key}:${o.value}' is not unique...`);
                
                keys.push(o.key);
                return <option key={i} value={o.key}>{o.value}</option>
            });
        }
            
    }

    render() {
		return (
			<MetadataInputContainer>
                <label>{this.props.label}</label>
                <select 
                    id={this.props.id}                    
                    value={this.props.onChange ? this.props.value : undefined}
                    defaultValue={this.props.onChange ? undefined : this.props.value}

                    disabled={this.props.disabled}
                    name={this.props.name}
                    required={this.props.required}

                    onChange={this.props.onChange}
                    style={{display: this.props.hidden === true ? 'none' : 'inherit'}}

                    className="metadata-select"
                >
                    {this.renderOptions()}
                </select>            
            </MetadataInputContainer>
		);
	}
}

export default MetadataSelect;