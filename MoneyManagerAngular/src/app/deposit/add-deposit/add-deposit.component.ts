import { Component, OnInit } from '@angular/core';
import { DepositService } from '../deposit.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepositDetails } from 'src/app/models/deposit-details.model';

@Component({
  selector: 'app-add-deposit',
  templateUrl: './add-deposit.component.html',
  styleUrls: ['./add-deposit.component.css']
})
export class AddDepositComponent implements OnInit {

  constructor(private depositService: DepositService, private formBuilder: FormBuilder) { }

  depositForm: FormGroup;
  depositDetails: DepositDetails;
  ngOnInit() {
    //Set deposit form with controls for
    //depositname, depositdate, and depositamounr
    this.depositForm = this.formBuilder.group({
      depositId: [0],
      depositSource: ['', [Validators.required, Validators.minLength(2)]],
      depositDate: ['', [Validators.required]],
      depositAmount: ['', [Validators.required]]
    });
  }

  saveDeposit(depositForm: FormGroup): void {
    console.log(JSON.stringify(depositForm.value));
    this.depositDetails = depositForm.value;
    console.log(this.depositDetails);
    this.depositService.addDeposit(this.depositDetails);
  }

}
