import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepositModule } from './deposit/deposit.module';
import { DepositService } from './deposit/deposit.service';
import { DatePipe } from '@angular/common';
import { ParameterService } from './parameters/parameter.service';
import { ParametersModule } from './parameters/parameters.module';
import { ExpensesModule } from './expenses/expenses.module';
import { ExpenseService } from './expenses/expense.service';
import { CommonPageModule } from './commonPage/common-page.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomePageModule } from './commonPage/home-page/home-page.module';
import { LoansModule } from './loans/loans.module';
import { LoanService } from './loans/loan.service';
import { SavingsParameterService } from './savings-parameters/savings-parameter.service';
import { SavingsParametersModule } from './savings-parameters/savings-parameters.module';
import { SeriesModule } from './series/series.module';
import { SeriesService } from './series/series.service';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DepositModule,
    ParametersModule,
    ExpensesModule,
    CommonPageModule,
    SavingsParametersModule,
    HomePageModule,
    LoansModule,
    BrowserAnimationsModule,
    SeriesModule,
    AngularFontAwesomeModule
  ],
  providers: [
    AppComponent,
    DepositService,
    ParameterService,
    ExpenseService,
    LoanService,
    SeriesService,
    SavingsParameterService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
