import { Component } from '@angular/core';
import { ILocations } from '../../model/ILocation';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    locations: ILocations[];
    constructor(route:ActivatedRoute) {
        this.locations = route.snapshot.data['locations'];
    }
}
