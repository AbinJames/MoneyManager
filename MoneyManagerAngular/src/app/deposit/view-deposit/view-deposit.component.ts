import { Component, OnInit } from '@angular/core';
import { DepositService } from '../deposit.service';
import { Deposit } from 'src/app/models/deposit.model';
import { DatePipe } from '@angular/common';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-view-deposit',
  templateUrl: './view-deposit.component.html',
  styleUrls: ['./view-deposit.component.css']
})
export class ViewDepositComponent implements OnInit {

  constructor(private depositService: DepositService, private datePipe: DatePipe, private appComponent: AppComponent) { }

  depositDetails: Deposit[];
  minAmount: number = 0;
  maxAmount: number = 1000;
  maxLimit: number = 0;

  depositStartDate: string;
  depositEndDate: string;
  minDateLimit: string;
  maxDateLimit: string;
  sumOfBalance: number[] = [];
  parameterToggleClicked: boolean[] = [];

  ngOnInit() {
    //initialize deposit list
    this.initializeDepositList();
  }

  //Function to get deposit details from server side
  initializeDepositList(): void {
    //gets list from service
    //sort first by time 
    //then by date
    this.depositService.getDeposit().subscribe(
      depositList => {
        this.depositDetails = depositList.sort(
          function (a, b) {
            return b.depositTime < a.depositTime ? -1 : 1;
          }).sort(
            function (a, b) {
              return b.depositDate < a.depositDate ? -1 : 1;
            });
        console.log("Deposit Content : " + JSON.stringify(this.depositDetails));

        //set list of sum of balances
        this.initializeSumOfBalances();

        //set amount range for filter
        this.initializeAmountRange();

        //set date range for filter
        this.initializeDateRange();

      }
    );
  }

  //function to initialize sumOfBalances to display total amount used for parameters in each deposit
  initializeSumOfBalances(): void {
    this.depositDetails.forEach(deposit => {
      this.parameterToggleClicked.push(false);
      console.log(deposit.entryModels);
      //if entrymodels is not null or empty set total amount added to parameters
      this.sumOfBalance.push(
        deposit.entryModels != null
          && deposit.entryModels.length != null
          && deposit.entryModels.length > 0
          ? deposit.entryModels.map(entry => entry.addedBalance).reduce((sum, current) => sum + current) : 0);
    });
  }

  //function to initialize amount range for filter
  initializeAmountRange(): void {
    //set max limit for amount range by filtering out the maximum amount in deposit list
    let depositAmountList = this.depositDetails.map(deposit => deposit.depositAmount);
    let maxDepositAmount = Math.max.apply(Math, depositAmountList);
    //round max value to next int
    this.maxAmount = this.maxLimit = Math.ceil(maxDepositAmount);
  }

  //function to initialize date range
  initializeDateRange(): void {
    //set max limit for date range by filtering out the maximum and minimum date in deposit list
    let depositDateList = this.depositDetails.map(deposit => deposit.depositDate);
    console.log(depositDateList);
    this.depositEndDate = this.maxDateLimit = this.datePipe.transform(depositDateList[0], "yyyy-MM-dd");
    this.depositStartDate = this.minDateLimit = this.datePipe.transform(depositDateList[depositDateList.length - 1], "yyyy-MM-dd");
  }

  //function to toggle dropdown icon change
  toggleCollapseIcon(index: number): void {
    this.parameterToggleClicked[index] = !this.parameterToggleClicked[index];
  }
}
