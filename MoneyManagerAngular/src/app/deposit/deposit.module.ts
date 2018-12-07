import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDepositComponent } from './add-deposit/add-deposit.component';
import { ViewDepositComponent } from './view-deposit/view-deposit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepositFilterPipe } from './deposit-filter.pipe';

@NgModule({
  declarations: [AddDepositComponent, ViewDepositComponent,DepositFilterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DepositModule { }
