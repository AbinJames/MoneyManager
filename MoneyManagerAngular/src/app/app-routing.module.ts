import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDepositComponent } from './deposit/add-deposit/add-deposit.component';
import { ViewDepositComponent } from './deposit/view-deposit/view-deposit.component';

const routes: Routes = [
  { path: 'add-deposit', component: AddDepositComponent},
  { path: 'view-deposit', component: ViewDepositComponent },
  { path: '', redirectTo: '/view-deposit', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
