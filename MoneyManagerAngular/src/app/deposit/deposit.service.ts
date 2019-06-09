import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class DepositService {

  constructor(private router:Router, private baseService: BaseService) { }

  baseApi: string = 'Deposit/';

  printToConsole(arg: string) {
    console.log("Connected to Deposit Module : "+arg);
  }

  addDeposit(deposit:any): void {
    //Post Invoice and corresponding rules to API to be saved in Database
    this.baseService.addData(this.baseApi + 'AddDeposit', deposit).subscribe(result => {
      console.log(result);
      //navigate to view component after post
      this.router.navigate(['view-deposit']);
    });
  }

  getDeposit():Observable<any[]>{
    //returns list of deposit details from api
    return this.baseService.getData(this.baseApi+'GetDeposit');
  }
}
