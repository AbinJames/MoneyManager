import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
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

  addLoan(loan:any): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddLoan', loan).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-loan']);
    });
  }

  getLoan():Observable<any[]>{
    //returns list of loan details from api
    return this.httpClient.get<any[]>(this.baseUrl+'GetLoans');
  }
}
