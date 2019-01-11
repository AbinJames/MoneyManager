import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { SavingsParameters } from 'src/app/models/savings-parameters.model';
import { SavingsParameterService } from '../savings-parameter.service';

@Component({
  selector: 'app-add-savings-parameters',
  templateUrl: './add-savings-parameters.component.html',
  styleUrls: ['./add-savings-parameters.component.css']
})
export class AddSavingsParametersComponent implements OnInit {

  constructor(private savingsParameterService: SavingsParameterService, private formBuilder: FormBuilder, private datePipe: DatePipe) { }

  savingsParameterForm: FormGroup;
  savingsParameterDetails: SavingsParameters;
  currentTime: string;
  currentDate: string

  ngOnInit() {
    //initialize reactive form controls
    this.initializeForm();
  }

  //Function to initialize reactive form
  initializeForm(): void {
    //Set savingsParameter form with controls for
    //savingsParametername, savingsParameterdate, and savingsParameteramount
    this.currentTime = this.datePipe.transform(new Date().toLocaleString(), "HH:mm");
    this.currentDate = this.datePipe.transform(new Date().toLocaleDateString(), "yyyy-MM-dd");
    console.log(this.currentTime, this.currentDate);
    this.savingsParameterForm = this.formBuilder.group({
      savingsParameterId: [0],
      savingsParameterName: ['', [Validators.required, Validators.minLength(2)]],
      savingsParameterBalance: [0],
    });
  }
  
  //Funtion to send data to serverside through service
  saveSavingsParameter(savingsParameterForm: FormGroup): void {
    console.log(JSON.stringify(savingsParameterForm.value));
    this.savingsParameterDetails = savingsParameterForm.value;
    console.log(this.savingsParameterDetails);
    this.savingsParameterService.addSavingsParameter(this.savingsParameterDetails);
  }

}
