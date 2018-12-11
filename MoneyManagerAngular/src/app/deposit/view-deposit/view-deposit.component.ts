import { Component, OnInit } from '@angular/core';
import { DepositService } from '../deposit.service';
import { DepositDetails } from 'src/app/models/deposit-details.model';
import { DatePipe } from '@angular/common';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-view-deposit',
  templateUrl: './view-deposit.component.html',
  styleUrls: ['./view-deposit.component.css']
})
export class ViewDepositComponent implements OnInit {

  constructor(private depositService: DepositService, private datePipe: DatePipe, private appComponent: AppComponent) { }

  depositDetails: DepositDetails[];
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
    //gets list from service
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
        // this.depositDetails.forEach(function (deposit){
        //   this.sumOfBalance.push(deposit.entryModels.map(entry=>entry.addedBalance).reduce((sum,current)=>sum+current));
        //   console.log(this.sumOfBalance);
        // });
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
        //set max limit for amount range by filtering out the maximum amount in deposit list
        let depositAmountList = this.depositDetails.map(deposit => deposit.depositAmount);
        let maxDepositAmount = Math.max.apply(Math, depositAmountList);
        //round max value to next int
        this.maxAmount = this.maxLimit = Math.ceil(maxDepositAmount);
        //set max limit for date range by filtering out the maximum and minimum date in deposit list
        let depositDateList = this.depositDetails.map(deposit => deposit.depositDate);
        console.log(depositDateList);
        this.depositEndDate = this.maxDateLimit = this.datePipe.transform(depositDateList[0], "yyyy-MM-dd");
        this.depositStartDate = this.minDateLimit = this.datePipe.transform(depositDateList[depositDateList.length - 1], "yyyy-MM-dd");
      }
    );
  }

  //function to toggle dropdown icon change
  toggleCollapseIcon(index: number): void {
    this.parameterToggleClicked[index] = !this.parameterToggleClicked[index];
  }
}
