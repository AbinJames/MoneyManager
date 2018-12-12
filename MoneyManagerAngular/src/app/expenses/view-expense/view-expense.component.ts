import { Component, OnInit } from '@angular/core';
import { ExpenseService } from '../expense.service';
import { Expense } from 'src/app/models/expense.model';
import { AppComponent } from 'src/app/app.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-view-expense',
  templateUrl: './view-expense.component.html',
  styleUrls: ['./view-expense.component.css']
})
export class ViewExpenseComponent implements OnInit {

  constructor(private expenseService: ExpenseService,private appComponent:AppComponent, private datePipe:DatePipe) { }

  expenseList: Expense[];
  minAmount: number = 0;
  maxAmount: number = 1000;
  maxLimit: number = 0;

  expenseStartDate: string;
  expenseEndDate: string;
  minDateLimit: string;
  maxDateLimit: string;

  ngOnInit() {
    //initialize expense list
    this.initializeExpenseList();
  }

  initializeExpenseList():void{
    //Get expense list from service
    this.expenseService.getExpense().subscribe(expense => {
      this.expenseList = expense;
      console.log("Expense content" + JSON.stringify(this.expenseList));

      //set amount range for filter
      this.initializeAmountRange();

      //set date range for filter
      this.initializeDateRange();

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
