import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Loan } from '../models/loan.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(private httpClient:HttpClient, private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/Loan/';

  printToConsole(arg) {
    console.log("Connected to Loans Module : "+arg);
  }

  addLoan(loan:Loan): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddLoan', loan).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-loan']);
    });
  }

  getLoan():Observable<Loan[]>{
    //returns list of loan details from api
    return this.httpClient.get<Loan[]>(this.baseUrl+'GetLoans');
  }
}
