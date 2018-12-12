import { Component, OnInit } from '@angular/core';
import { DepositService } from '../deposit.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepositDetails } from 'src/app/models/deposit-details.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-deposit',
  templateUrl: './add-deposit.component.html',
  styleUrls: ['./add-deposit.component.css']
})
export class AddDepositComponent implements OnInit {

  constructor(private depositService: DepositService, private formBuilder: FormBuilder, private datePipe: DatePipe) { }

  depositForm: FormGroup;
  depositDetails: DepositDetails;
  currentTime: string;
  currentDate: string

  ngOnInit() {
    //initialize reactive form controls
    this.initializeForm();
  }

  //Function to initialize reactive form
  initializeForm(): void {
    //Set deposit form with controls for
    //depositname, depositdate, and depositamount
    this.currentTime = this.datePipe.transform(new Date().toLocaleString(), "HH:mm");
    this.currentDate = this.datePipe.transform(new Date().toLocaleDateString(), "yyyy-MM-dd");
    console.log(this.currentTime, this.currentDate);
    this.depositForm = this.formBuilder.group({
      depositId: [0],
      depositSource: ['', [Validators.required, Validators.minLength(2)]],
      depositDate: [this.currentDate, [Validators.required, Validators.minLength(2)]],
      depositTime: [this.currentTime, [Validators.required, Validators.minLength(2)]],
      depositAmount: ['', [Validators.required]]
    });
  }
  
  //Funtion to send data to serverside through service
  saveDeposit(depositForm: FormGroup): void {
    console.log(JSON.stringify(depositForm.value));
    this.depositDetails = depositForm.value;
    console.log(this.depositDetails);
    this.depositService.addDeposit(this.depositDetails);
  }

}
