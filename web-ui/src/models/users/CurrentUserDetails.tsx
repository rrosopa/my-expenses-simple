export interface ICurrentUserDetails {
    fullName: string;
    prefferedName: string;
    email: string;
    
    title: string;
}

export class CurrentUserDetails implements ICurrentUserDetails {
    fullName: string;    
    prefferedName: string;
    email: string;
    title: string;

    constructor() {
        this.fullName = '';
        this.prefferedName = '';
        this.email = '';
        this.title = '';
    }
}