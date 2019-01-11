import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSavingsParametersComponent } from './add-savings-parameters/add-savings-parameters.component';
import { ViewSavingsParametersComponent } from './view-savings-parameters/view-savings-parameters.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { SavingsParameterFilterPipe } from './savings-parameter-filter.pipe';

@NgModule({
  declarations: [AddSavingsParametersComponent, ViewSavingsParametersComponent, SavingsParameterFilterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ]
})
export class SavingsParametersModule { }
