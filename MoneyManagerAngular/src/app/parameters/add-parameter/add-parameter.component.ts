import { Component, OnInit } from '@angular/core';
import { ParameterService } from '../parameter.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Parameters } from 'src/app/models/parameters.model';

@Component({
  selector: 'app-add-parameter',
  templateUrl: './add-parameter.component.html',
  styleUrls: ['./add-parameter.component.css']
})
export class AddParameterComponent implements OnInit {

  constructor(private parameterService: ParameterService, private formBuilder: FormBuilder, private datePipe: DatePipe) { }

  parameterForm: FormGroup;
  parameterDetails: Parameters;
  currentTime: string;
  currentDate: string

  ngOnInit() {
    //initialize reactive form controls
    this.initializeForm();
  }

  //Function to initialize reactive form
  initializeForm(): void {
    //Set parameter form with controls for
    //parametername, parameterdate, and parameteramount
    this.currentTime = this.datePipe.transform(new Date().toLocaleString(), "HH:mm");
    this.currentDate = this.datePipe.transform(new Date().toLocaleDateString(), "yyyy-MM-dd");
    console.log(this.currentTime, this.currentDate);
    this.parameterForm = this.formBuilder.group({
      parameterId: [0],
      parameterName: ['', [Validators.required, Validators.minLength(2)]],
      parameterAmount: ['', [Validators.required]],
      parameterBalance: [0],
    });
  }
  
  //Funtion to send data to serverside through service
  saveParameter(parameterForm: FormGroup): void {
    console.log(JSON.stringify(parameterForm.value));
    this.parameterDetails = parameterForm.value;
    console.log(this.parameterDetails);
    this.parameterService.addParameter(this.parameterDetails);
  }

}
