import { Http, Response, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { IField } from './IField';

@Injectable()
export class DbsApiService {

    constructor(private _http: Http) {
    }

    fields: IField[] = [];

    public getFields = (actionUrl): IField[] => {
        this._http.get(actionUrl).map(data => data.json()).subscribe(data => this.fields = data);

        return this.fields;
    }

    public saveMappings = (fields: IField[]) => {
        let url = 'http://localhost:2606/home/SaveMappings';

        console.log(JSON.stringify(fields));

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        return this._http.post(url, fields, { headers: headers }).subscribe();
    }
        
}