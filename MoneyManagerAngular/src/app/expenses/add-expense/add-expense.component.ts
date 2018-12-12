import { Component, OnInit } from '@angular/core';
import { ExpenseService } from '../expense.service';
import { Expense } from 'src/app/models/expense.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ParameterService } from 'src/app/parameters/parameter.service';
import { Parameters } from 'src/app/models/parameters.model';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent implements OnInit {

  constructor(private parameterService: ParameterService, private expenseService: ExpenseService, private formBuilder: FormBuilder, private datePipe: DatePipe) { }

  expenseForm: FormGroup;
  expense: Expense;
  parameterList: Parameters[];
  currentTime: string;
  currentDate: string

  ngOnInit() {
    //Function to get parameters for expense
    this.getParameters();
    //initialize reactive form
    this.initializeForm();
  }

  //Function to get parameters for expense
  getParameters(): void {
    this.parameterService.getParameters().subscribe(parameterList => {
      this.parameterList = parameterList;
    });
  }

  //initialize reactive form
  initializeForm(): void {
    //Set expense form with controls for
    //expensename, expensedate, and expenseamount
    this.currentTime = this.datePipe.transform(new Date().toLocaleString(), "HH:mm");
    this.currentDate = this.datePipe.transform(new Date().toLocaleDateString(), "yyyy-MM-dd");
    console.log(this.currentTime, this.currentDate);
    this.expenseForm = this.formBuilder.group({
      expenseId: [0],
      parameterId: [1, [Validators.required]],
      expenseDetails: ['', [Validators.required, Validators.minLength(2)]],
      expenseDate: [this.currentDate, [Validators.required, Validators.minLength(2)]],
      expenseTime: [this.currentTime, [Validators.required, Validators.minLength(2)]],
      expenseAmount: ['', [Validators.required]]
    });
  }

  //Call service to send data to serverside
  saveExpense(expenseForm: FormGroup): void {
    console.log(JSON.stringify(expenseForm.value));
    this.expense = expenseForm.value;
    console.log(this.expense);
    this.expenseService.addExpense(this.expense);
  }

}
