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
    ExpensesModule
  ],
  providers: [
    AppComponent,
    DepositService,
    ParameterService,
    ExpenseService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
