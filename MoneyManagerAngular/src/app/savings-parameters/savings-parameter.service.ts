import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { SavingsParameters } from '../models/savings-parameters.model';

@Injectable({
  providedIn: 'root'
})
export class SavingsParameterService {

  constructor(private httpClient:HttpClient,private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/SavingsParameters/';

  printToConsole(arg) {
    console.log("Connected to SavingsParameter Module : "+arg);
  }

  addSavingsParameter(savingsParameter:SavingsParameters): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddSavingsParameter', savingsParameter).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-savings-parameter']);
    });
  }

  getSavingsParameters():Observable<SavingsParameters[]>{
    //returns list of savingsParameter details from api
    return this.httpClient.get<SavingsParameters[]>(this.baseUrl+'GetSavingsParameters');
  }
}
