import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddLoanComponent } from './add-loan/add-loan.component';
import { ViewLoanComponent } from './view-loan/view-loan.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [AddLoanComponent, ViewLoanComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ]
})
export class LoansModule { }
