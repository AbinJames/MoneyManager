import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewSeriesComponent } from './view-series/view-series.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

@NgModule({
  declarations: [ViewSeriesComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    AngularFontAwesomeModule
  ]
})
export class SeriesModule { }
