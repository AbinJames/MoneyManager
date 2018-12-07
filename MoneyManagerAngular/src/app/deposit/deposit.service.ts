import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DepositDetails } from '../models/deposit-details.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepositService {

  constructor(private httpClient:HttpClient, private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/Deposit/';

  printToConsole(arg) {
    console.log("Connected to Deposit Modeule : "+arg);
  }

  addDeposit(deposit:DepositDetails): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddDeposit', deposit).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-deposit']);
    });
  }

  getDeposit():Observable<DepositDetails[]>{
    //returns list of deposit details from api
    return this.httpClient.get<DepositDetails[]>(this.baseUrl+'GetDeposit');
  }
}
