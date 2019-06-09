import { Component, OnInit } from '@angular/core';
import { ExpenseService } from '../expense.service';
import { AppComponent } from 'src/app/app.component';
import { DatePipe } from '@angular/common';
import { ParameterService } from 'src/app/parameters/parameter.service';
import { SavingsParameterService } from 'src/app/savings-parameters/savings-parameter.service';

@Component({
  selector: 'app-view-expense',
  templateUrl: './view-expense.component.html',
  styleUrls: ['./view-expense.component.css']
})
export class ViewExpenseComponent implements OnInit {

  constructor(private expenseService: ExpenseService, private parameterService: ParameterService, private savingsParameterService:SavingsParameterService, private appComponent: AppComponent, private datePipe: DatePipe) { }

  expenseList: any[];
  minAmount: number = 0;
  maxAmount: number = 1000;
  maxLimit: number = 0;

  expenseStartDate: string;
  expenseEndDate: string;
  minDateLimit: string;
  maxDateLimit: string;
  parameterList: any[];
  savingsParameterList: any[];

  ngOnInit() {

    //Function to get parameters for expense
    this.getParameters();

    //Function to get savings parameters
    this.getSavingsParameters();

    //initialize expense list
    this.initializeExpenseList();
  }

  initializeExpenseList(): void {
    //Get expense list from service
    this.expenseService.getExpense().subscribe(expense => {
      this.expenseList = expense;
      console.log("Expense content " + JSON.stringify(this.expenseList));

      //set amount range for filter
      this.initializeAmountRange();

      //set date range for filter
      this.initializeDateRange();

    });
  }

   //Function to get parameters for expense
   getParameters(): void {
    this.parameterService.getParameters().subscribe(parameterList => {
      this.parameterList = parameterList;
    });
  }

  //Function to get savings parameters
  getSavingsParameters(): void {
    this.savingsParameterService.getSavingsParameters().subscribe(savingsParameters => {
      this.savingsParameterList = savingsParameters;
    });
  }

  //function to initialize amount range for filter
  initializeAmountRange(): void {
    //set max limit for amount range by filtering out the maximum amount in expense list
    let expenseAmountList = this.expenseList.map(expense => expense.expenseAmount);
    let maxDepositAmount = Math.max.apply(Math, expenseAmountList);
    //round max value to next int
    this.maxAmount = this.maxLimit = Math.ceil(maxDepositAmount);
  }

  //function to initialize date range
  initializeDateRange(): void {
    //set max limit for date range by filtering out the maximum and minimum date in expense list
    let expenseDateList = this.expenseList.map(expense => expense.expenseDate);
    console.log(expenseDateList);
    this.expenseEndDate = this.maxDateLimit = this.datePipe.transform(expenseDateList[0], "yyyy-MM-dd");
    this.expenseStartDate = this.minDateLimit = this.datePipe.transform(expenseDateList[expenseDateList.length - 1], "yyyy-MM-dd");
  }
}
