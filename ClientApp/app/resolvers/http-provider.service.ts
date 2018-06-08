import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ILocations } from '../model/ILocation';
import 'rxjs/add/operator/map';

@Injectable()
export class HttpProviderService {
    constructor(private http: Http) {

    }

    getServices(): Observable<ILocations[]> {
        return this.http.get("/Home/Locations").map(x => x.json())
    }
}