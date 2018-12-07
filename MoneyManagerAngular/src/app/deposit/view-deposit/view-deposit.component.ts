import { Component, OnInit } from '@angular/core';
import { DepositService } from '../deposit.service';
import { DepositDetails } from 'src/app/models/deposit-details.model';

@Component({
  selector: 'app-view-deposit',
  templateUrl: './view-deposit.component.html',
  styleUrls: ['./view-deposit.component.css']
})
export class ViewDepositComponent implements OnInit {

  constructor(private depositService: DepositService) { }

  depositDetails: DepositDetails[];
  filterEnabled: boolean = false;

  ngOnInit() {

    //gets list from service
    this.depositService.getDeposit().subscribe(
      depositList => {
        this.depositDetails = depositList;
        console.log("Deposit Content : " + this.depositDetails)
      }
    );
  }

  //function to toggle filtering
  toggleFilter(): void {
    this.filterEnabled = !this.filterEnabled;
  }

}
