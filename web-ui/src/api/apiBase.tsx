import { appConstants } from "../constants/appConstants";

export enum APIMethods {
    GET = 'GET',
    POST = 'POST',
    PUT = 'PUT'
}

function appFetch<T>(url: string, method: APIMethods, data?: Object): Promise<T> {
    return fetch(url, {
        method: method,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem(appConstants.token)}`
        },
        body: data == null ? undefined : JSON.stringify(data)
    })
    .then(response => {
        if(response.status === 401){
            // redirect to login page?
        }
        else if(response.status === 403){
            // redirect to forbidden/warning page?
        }

        return response.json();
    })
    .catch(error => {
        console.log('An error occured. ', error);
        throw error;
    })
}


export const api = {
    get: function<T>(url: string): Promise<T> {
        return appFetch<T>(url, APIMethods.GET);
    },
    post: function<T>(url: string, data: object): Promise<T> {
        return appFetch<T>(url, APIMethods.POST, data);
    },
    put: function<T>(url: string, data: object): Promise<T> {
        return appFetch<T>(url, APIMethods.PUT, data);
    } 
}