import { Component, OnInit } from '@angular/core';
import { ParameterService } from '../parameter.service';
import { AmountSplitParameter } from 'src/app/models/amount-split-parameters.model';
import { AppComponent } from 'src/app/app.component';
import { DepositService } from 'src/app/deposit/deposit.service';

@Component({
  selector: 'app-view-parameter',
  templateUrl: './view-parameter.component.html',
  styleUrls: ['./view-parameter.component.css']
})
export class ViewParameterComponent implements OnInit {

  constructor(private parameterService: ParameterService, private appComponent: AppComponent,private depositService:DepositService) { }

  parameterList: AmountSplitParameter[];
  maxLimit: number;
  maxAmount: number;
  minAmount: number = 0;
  maxBalanceLimit:number;
  maxBalance:number;
  minBalance:number=0;
  totalBalance:number=0;
  totalDeposit:number=0;
  ngOnInit() {
    this.depositService.getDeposit().subscribe(
      depositList => {
        this.totalDeposit = depositList.map(deposit=>deposit.depositAmount).reduce((sum,current)=>sum+current);
      }
    );
    this.parameterService.getParameters().subscribe(parameters => {
      this.parameterList = parameters.sort((firstItem, secondItem) => firstItem.parameterName < secondItem.parameterName ? -1 : 1);
      //set max limit for amount range by filtering out the maximum amount in parameter list
      let parameterAmountList = this.parameterList.map(parameter => parameter.parameterAmount);
      let maxParameterAmount = Math.max.apply(Math, parameterAmountList);
      this.totalBalance = this.parameterList.map(parameter=>parameter.parameterBalance).reduce((sum,current)=>sum+current);
      //round max value to next int
      this.maxAmount = this.maxLimit = Math.ceil(maxParameterAmount);

       //set max limit for balance range by filtering out the maximum balance in parameter list
       let parameterBalanceList = this.parameterList.map(parameter => parameter.parameterBalance);
       let maxParameterBalance = Math.max.apply(Math, parameterBalanceList);
       //round max value to next int
       this.maxBalance = this.maxBalanceLimit = Math.ceil(maxParameterBalance);
    });
  }

}
