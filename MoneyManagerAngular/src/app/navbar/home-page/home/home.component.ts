import { Component, OnInit } from '@angular/core';
import { DepositService } from 'src/app/deposit/deposit.service';
import { ParameterService } from 'src/app/parameters/parameter.service';
import { ExpenseService } from 'src/app/expenses/expense.service';
import { Deposit } from 'src/app/models/deposit.model';
import { Expense } from 'src/app/models/expense.model';
import { Parameters } from 'src/app/models/parameters.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private depositService: DepositService,
    private parameterService: ParameterService,
    private expenseService: ExpenseService) { }

  depositDetails: Deposit[];
  expenseList: Expense[];
  parameterList: Parameters[];

  totalbalance:number;
  total
  ngOnInit() {
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
      }
    );
  }

  //function to initialize expense list
  initializeExpenseList(): void {
    //Get expense list from service
    this.expenseService.getExpense().subscribe(expense => {
      this.expenseList = expense;
      console.log("Expense content" + JSON.stringify(this.expenseList));
    });
  }

  //Function to initilaize the parameter list
  initializeParameterList(): void {
    this.parameterService.getParameters().subscribe(parameters => {
      //sort list by name
      this.parameterList = parameters
        .sort((firstItem, secondItem) => firstItem.parameterName < secondItem.parameterName ? -1 : 1);
    });
  }
}
