import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AmountSplitParameter } from '../models/amount-split-parameters.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {

  constructor(private httpClient:HttpClient,private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/AmountSplitParameter/';

  printToConsole(arg) {
    console.log("Connected to Parameter Module : "+arg);
  }

  // addParameter(deposit:DepositDetails): void {
  //   //Post Invoice and corresponding rules to API to be saved in Database
  //   this.httpClient.post(this.baseUrl + 'AddDeposit', deposit).subscribe(result => {
  //     console.log(result);
  //     //navigate to view component after post
  //     this.router.navigate(['view-deposit']);
  //   });
  // }

  getParameters():Observable<AmountSplitParameter[]>{
    //returns list of deposit details from api
    return this.httpClient.get<AmountSplitParameter[]>(this.baseUrl+'GetParameters');
  }
}
