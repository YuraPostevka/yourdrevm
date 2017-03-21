import { Component, Input, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Pipe, PipeTransform } from '@angular/core';

import { IField } from './IField';
import { DbsApiService } from './dbsApiService';

@Component({
    selector: 'dbs-map-tool',
    templateUrl: './dbs-map-tool.component.html',
    styleUrls: ["./dbs-map-tool.component.css"]
})

export class DbsMapToolComponent implements OnInit {

    fields:any = [

        {
            'FieldName': 'name1',
            'Checked': false, 'Map': '', 'DestinationField': ''
        },
        {
            'FieldName': 'name2',
            'Checked': false, 'Map': '', 'DestinationField': ''
        },
        {
            'FieldName': 'name3',
            'Checked': false, 'Map': '', 'DestinationField': ''
        },
        {
            'FieldName': 'name4',
            'Checked': false, 'Map': '', 'DestinationField': ''
        },
        {
            'FieldName': 'name5',
            'Checked': false, 'Map': '', 'DestinationField': ''
        },
        {
            'FieldName': 'name6',
            'Checked': false, 'Map': '', 'DestinationField': ''
        }

    ];
    


    //TODO: refactor to location
    private url = 'http://localhost:2606/home/GetFields/?projectId=';

    @Input()
    projectId: number;

    constructor(private _service: DbsApiService) {

    }

    ngOnInit() {
        console.log("OnInit");
    }

    loadFields() {

        this.fields = this._service.getFields(this.url + this.projectId.toString());
    }

    saveMappings(fields: IField[]) {
        this._service.saveMappings(fields);
    }

    deSelectFiltered() {
        this.fields.forEach(i => i.Checked = false);
    }

    setProfileMap() {	
		this.fields.filter(i => i.Checked == true).forEach(i => i.Map = 'ProfileMap');
        this.deSelectFiltered();
    }
    setSurveyMap() {
        this.fields.filter(i => i.Checked == true).forEach(i => i.Map = 'SurveyMap');
        this.deSelectFiltered();
    }
    setPanelistMap() {
        this.fields.filter(i => i.Checked == true).forEach(i => i.Map = 'PanelistMap');
        this.deSelectFiltered();
    }
    resetFieldMap(field: IField) {
        field.Map = null;
    }

}