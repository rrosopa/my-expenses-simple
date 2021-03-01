import { IData } from "../models/common/data";
import moment from "moment";

export const queryHelper = {
    buildQueryFromObject: function(obj: IData): string {
        var params = ''
        if(obj !== null && obj !== undefined){            
            var props = Object.keys(obj);
            for(var i = 0; i < props.length; i++){
                if(obj[props[i]] !== null && obj[props[i]] !== undefined && obj[props[i]] !== 'null'){
                    var value;
                    if(typeof obj[props[i]].getMonth === 'function'){
                        value = moment(obj[props[i]]).format('L');
                    }
                    else if(typeof obj[props[i]].format === 'function'){
                        value = obj[props[i]].format('L');
                    }
                    else{
                        value = obj[props[i]]
                    }
                    params += `${props[i]}=${encodeURI(value)}&`;
                }
            }

            if(params.length > 0){
                params = `?${params}`;
            }
        }

        return params;
    },
    getValueFromQueryParams: function(search: string, propName: string){
        if(search && propName && search.length > 2 && search.indexOf('?') === 0){  
            var params = search.substring(1).split('&')          
            for(var i = 0; i < params.length; i++ ) {
                if(params[i].startsWith(`${propName}=`)){
                    var temp = params[i].split('=');
                    return temp.length === 2 ? temp[1] : null; 
                }
            }
        }

        return null;
    },
    replaceValueFromQueryParams: function(search: string, propName: string, newValue: string): string{
        if(search && propName && search.length > 2 && search.indexOf('?') === 0){  
            var params = search.substring(1).split('&')          
            for(var i = 0; i < params.length; i++ ) {
                if(params[i].startsWith(`${propName}=`)){
                    params[i] = `${propName}=${newValue}`;
                    break; 
                }
            }

            search = '?' + params.join('&');
        }

        return search;
    }
}