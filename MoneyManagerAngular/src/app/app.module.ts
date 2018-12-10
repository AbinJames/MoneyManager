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

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DepositModule,
    ParametersModule
  ],
  providers: [
    AppComponent,
    DepositService,
    ParameterService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
