import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { DepositService } from 'src/app/deposit/deposit.service';
import { SavingsParameterService } from '../savings-parameter.service';
import { SavingsParameters } from 'src/app/models/savings-parameters.model';

@Component({
  selector: 'app-view-savings-parameters',
  templateUrl: './view-savings-parameters.component.html',
  styleUrls: ['./view-savings-parameters.component.css']
})
export class ViewSavingsParametersComponent implements OnInit {

  constructor(private savingsParameterService: SavingsParameterService, private appComponent: AppComponent, private depositService: DepositService) { }

  savingsParameterList: SavingsParameters[];
  maxLimit: number;
  maxAmount: number;
  minAmount: number = 0;
  maxBalanceLimit: number;
  maxBalance: number;
  minBalance: number = 0;
  totalBalance: number = 0;
  totalDeposit: number = 0;

  ngOnInit() {

    //set total deposit
    this.setTotalDeposit();

    //initialize savingsParameter list
    this.initializeSavingsParameterList();
  }

  //Function to set the total deposit
  setTotalDeposit(): void {
    this.depositService.getDeposit().subscribe(
      depositList => {
        this.totalDeposit = depositList.map(deposit => deposit.depositAmount).reduce((sum, current) => sum + current);
      }
    );
  }

  //Function to initilaize the savingsParameter list
  initializeSavingsParameterList(): void {
    this.savingsParameterService.getSavingsParameters().subscribe(savingsParameters => {
      //sort list by name
      this.savingsParameterList = savingsParameters.sort((firstItem, secondItem) => firstItem.savingsParameterName < secondItem.savingsParameterName ? -1 : 1);

      //set balance range for filter
      this.setBalanceRange();
    });
  }

  //function to set balance range for filter
  setBalanceRange(): void {
    //set max limit for balance range by filtering out the maximum balance in savingsParameter list
    let savingsParameterBalanceList = this.savingsParameterList.map(savingsParameter => savingsParameter.savingsParameterBalance);
    let maxSavingsParameterBalance = Math.max.apply(Math, savingsParameterBalanceList);
    //round max value to next int
    this.maxBalance = this.maxBalanceLimit = Math.ceil(maxSavingsParameterBalance);
  }
}
