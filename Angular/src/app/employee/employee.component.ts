import {Component} from '@angular/core'

@Component({
    selector: 'my-employee',
    templateUrl: 'app/employee/employee.component.html',
    styleUrls:['app/employee/employee.component.css']
})
export class EmployeeComponent {
    firstName: string = "PV";
    lastName: string = "jayasimha";
    gender: string = "Male";
    age: number = 22;
    showDetails: boolean = false;
    toggleDetails(): void {
    this.showDetails = !this.showDetails;
}
}