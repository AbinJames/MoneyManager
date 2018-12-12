import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { ViewExpenseComponent } from './view-expense/view-expense.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExpenseFilterPipe } from './expense-filter.pipe';

@NgModule({
  declarations: [AddExpenseComponent, ViewExpenseComponent,ExpenseFilterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ExpensesModule { }
