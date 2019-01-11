import { Component, OnInit } from '@angular/core';
import { LoanService } from '../loan.service';
import { Loan } from 'src/app/models/loan.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Parameters } from 'src/app/models/parameters.model';

@Component({
  selector: 'app-add-loan',
  templateUrl: './add-loan.component.html',
  styleUrls: ['./add-loan.component.css']
})
export class AddLoanComponent implements OnInit {

  constructor(private loanService: LoanService, private formBuilder: FormBuilder, private datePipe: DatePipe) { }

  loanForm: FormGroup;
  loan: Loan;
  currentDate: string

  ngOnInit() {
    //initialize reactive form
    this.initializeForm();
  }

  //initialize reactive form
  initializeForm(): void {
    //Set loan form with controls for
    //loanname, loandate, and loanamount
    this.currentDate = this.datePipe.transform(new Date().toLocaleDateString(), "yyyy-MM-dd");
    console.log(this.currentDate);
    this.loanForm = this.formBuilder.group({
      loanId: [0],
      loanDetails: ['', [Validators.required, Validators.minLength(2)]],
      loanPerson: ['', [Validators.required, Validators.minLength(2)]],
      loanStartDate: [this.currentDate, [Validators.required, Validators.minLength(2)]],
      loanEndDate: [this.currentDate, [Validators.required, Validators.minLength(2)]],
      isLoanPayedToYou: [true],
      isLoanPayed: [false],
      loanAmount: ['', [Validators.required]]
    });
  }

  //Call service to send data to serverside
  saveLoan(loanForm: FormGroup): void {
    console.log(JSON.stringify(loanForm.value));
    this.loan = loanForm.value;
    console.log(this.loan);
    this.loanService.addLoan(this.loan);
  }

}
