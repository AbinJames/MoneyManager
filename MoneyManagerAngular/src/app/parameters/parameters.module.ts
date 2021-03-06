import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddParameterComponent } from './add-parameter/add-parameter.component';
import { ViewParameterComponent } from './view-parameter/view-parameter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ParameterFilterPipe } from './parameter-filter.pipe';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [AddParameterComponent, ViewParameterComponent, ParameterFilterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ]
})
export class ParametersModule { }
