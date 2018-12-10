import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepositModule } from './deposit/deposit.module';
import { DepositService } from './deposit/deposit.service';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DepositModule
  ],
  providers: [
    DepositService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
