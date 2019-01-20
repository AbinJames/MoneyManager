import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDepositComponent } from './add-deposit/add-deposit.component';
import { ViewDepositComponent } from './view-deposit/view-deposit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepositFilterPipe } from './deposit-filter.pipe';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [AddDepositComponent, ViewDepositComponent, DepositFilterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ]
})
export class DepositModule { }
