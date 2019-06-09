import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private httpClient:HttpClient, private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/Expense/';

  printToConsole(arg) {
    console.log("Connected to Expense Module : "+arg);
  }

  addExpense(expense:any): void {
    //Post expense details and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddExpense', expense).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-expense']);
    });
  }

  getExpense():Observable<any[]>{
    //returns list of expense details from api
    return this.httpClient.get<any[]>(this.baseUrl+'GetExpense');
  }
}
