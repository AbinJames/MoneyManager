import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDepositComponent } from './deposit/add-deposit/add-deposit.component';
import { ViewDepositComponent } from './deposit/view-deposit/view-deposit.component';
import { ViewParameterComponent } from './parameters/view-parameter/view-parameter.component';
import { AddParameterComponent } from './parameters/add-parameter/add-parameter.component';
import { ViewExpenseComponent } from './expenses/view-expense/view-expense.component';
import { AddExpenseComponent } from './expenses/add-expense/add-expense.component';
import { HomeComponent } from './navbar/home-page/home/home.component';

const routes: Routes = [
  { path: 'view-home', component: HomeComponent },
  { path: 'add-deposit', component: AddDepositComponent },
  { path: 'view-deposit', component: ViewDepositComponent },
  { path: 'add-parameter', component: AddParameterComponent },
  { path: 'view-parameter', component: ViewParameterComponent },
  { path: 'add-expense', component: AddExpenseComponent },
  { path: 'view-expense', component: ViewExpenseComponent },
  { path: '', redirectTo: '/view-home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
