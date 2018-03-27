import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: `app/app.component.html`
    //templateUrl:'<my-employee></my-employee>'
})
export class AppComponent {
    pageHeader: string = "Employee Details";
    ImageUrl: string = "https://angular.io/assets/images/logos/angular/angular.svg";
    firstName: string = "Jayasimha"; 
    lastName: string = " PV";
    getFullName(): string {
        return this.firstName + '' + this.lastName;
    }
    isDisabled: boolean = false;
}