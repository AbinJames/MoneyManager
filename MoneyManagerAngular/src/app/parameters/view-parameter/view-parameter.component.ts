import { Component, OnInit } from '@angular/core';
import { ParameterService } from '../parameter.service';
import { AmountSplitParameter } from 'src/app/models/amount-split-parameters.model';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-view-parameter',
  templateUrl: './view-parameter.component.html',
  styleUrls: ['./view-parameter.component.css']
})
export class ViewParameterComponent implements OnInit {

  constructor(private parameterService: ParameterService, private appComponent: AppComponent) { }

  parameterList: AmountSplitParameter[];
  maxLimit: number;
  maxAmount: number;
  minAmount: number = 0;
  ngOnInit() {
    this.parameterService.getParameters().subscribe(parameters => {
      this.parameterList = parameters.sort((firstItem, secondItem) => firstItem.parameterName < secondItem.parameterName ? -1 : 1);
      //set max limit for amount range by filtering out the maximum amount in parameter list
      let parameterAmountList = this.parameterList.map(parameter => parameter.parameterAmount);
      let maxParameterAmount = Math.max.apply(Math, parameterAmountList);
      //round max value to next int
      this.maxAmount = this.maxLimit = Math.ceil(maxParameterAmount);
    });
  }

}
