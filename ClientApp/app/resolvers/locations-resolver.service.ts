import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ILocations } from '../model/ILocation';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';
import { HttpProviderService } from './http-provider.service';

@Injectable()
export class LocationsResolverService implements Resolve<Observable<ILocations[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ILocations[]> {
        return this.http.getServices()
    }
    constructor(private http:HttpProviderService) {

    }
}