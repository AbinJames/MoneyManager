import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {

  constructor(private httpClient:HttpClient,private router:Router) { }

  baseUrl: string = 'https://localhost:44379/api/MoneyManager/Parameters/';

  printToConsole(arg) {
    console.log("Connected to Parameter Module : "+arg);
  }

  addParameter(parameter:any): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.httpClient.post(this.baseUrl + 'AddParameter', parameter).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-parameter']);
    });
  }

  getParameters():Observable<any[]>{
    //returns list of parameter details from api
    return this.httpClient.get<any[]>(this.baseUrl+'GetParameters');
  }
}
