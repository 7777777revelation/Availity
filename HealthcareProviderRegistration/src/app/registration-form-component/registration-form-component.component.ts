import { Component, OnInit } from '@angular/core';
import { HealthcareProvider } from '../healthcare-provider';

@Component({
  selector: 'app-registration-form-component',
  templateUrl: './registration-form-component.component.html',
  styleUrls: ['./registration-form-component.component.css']
})
export class RegistrationFormComponentComponent  {
 
  model = new HealthcareProvider('','','','','','');

  submit(login){
    console.log("form submitted", login);
    console.log(`model.Firstname is ${this.model.Firstname}`);
    console.log(`model.Lastname is ${this.model.Lastname}`);
    console.log(`model.NpiNumber is ${this.model.NpiNumber}`);
    console.log(`model.BusinessAddress is ${this.model.BusinessAddress}`);
    console.log(`model.TelephoneNumber is ${this.model.TelephoneNumber}`);
    console.log(`model.Email is ${this.model.Email}`);        
  }
}
