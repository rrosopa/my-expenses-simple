export enum MetadataControlType {
    Input,
    Select
}

export default interface IMetadataControl{
    controlType: MetadataControlType;
    id: string;
    label: string;
    value: string | number;

    disabled?: boolean;
    error?: string;
    hidden?: boolean;
    index?: number;
    name?: string;   
    placeholder?: string; 
    required?: boolean;
    width?: number | string;
}