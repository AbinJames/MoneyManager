import { Component, OnInit } from '@angular/core';
import { LoanService } from '../loan.service';
import { AppComponent } from 'src/app/app.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-view-loan',
  templateUrl: './view-loan.component.html',
  styleUrls: ['./view-loan.component.css']
})
export class ViewLoanComponent implements OnInit {


  constructor(private loanService: LoanService,private appComponent:AppComponent, private datePipe:DatePipe) { }

  loanList: any[];
  minAmount: number = 0;
  maxAmount: number = 1000;
  maxLimit: number = 0;

  loanStartStartDate: string;
  loanStartEndDate: string;
  minStartDateLimit: string;
  maxStartDateLimit: string;

  loanEndStartDate: string;
  loanEndEndDate: string;
  minEndDateLimit: string;
  maxEndDateLimit: string;

  ngOnInit() {
    //initialize loan list
    this.initializeLoanList();
  }

  initializeLoanList():void{
    //Get loan list from service
    this.loanService.getLoan().subscribe(loan => {
      this.loanList = loan;
      console.log("Loan content" + JSON.stringify(this.loanList));

      //set amount range for filter
      this.initializeAmountRange();

      //set date range for filter
      this.initializeDateRange();

    });
  }

  //function to initialize amount range for filter
  initializeAmountRange(): void {
    //set max limit for amount range by filtering out the maximum amount in loan list
    let loanAmountList = this.loanList.map(loan => loan.loanAmount);
    let maxDepositAmount = Math.max.apply(Math, loanAmountList);
    //round max value to next int
    this.maxAmount = this.maxLimit = Math.ceil(maxDepositAmount);
  }

  //function to initialize date range
  initializeDateRange(): void {
    //set max limit for date range by filtering out the maximum and minimum date in loan list
    let loanStartDateList = this.loanList.map(loan => loan.loanStartDate);
    console.log(loanStartDateList);
    this.loanStartEndDate = this.maxStartDateLimit = this.datePipe.transform(loanStartDateList[0], "yyyy-MM-dd");
    this.loanStartStartDate = this.minStartDateLimit = this.datePipe.transform(loanStartDateList[loanStartDateList.length - 1], "yyyy-MM-dd");

    let loanEndDateList = this.loanList.map(loan => loan.loanStartDate);
    console.log(loanEndDateList);
    this.loanEndEndDate = this.maxEndDateLimit = this.datePipe.transform(loanEndDateList[0], "yyyy-MM-dd");
    this.loanEndStartDate = this.minEndDateLimit = this.datePipe.transform(loanEndDateList[loanEndDateList.length - 1], "yyyy-MM-dd");
  }
}
