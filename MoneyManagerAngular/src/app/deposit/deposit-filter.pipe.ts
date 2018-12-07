import { Pipe, PipeTransform } from '@angular/core';
import { DepositDetails } from '../models/deposit-details.model';

@Pipe({ name: 'DepositFilterPipe' })

export class DepositFilterPipe implements PipeTransform {
    transform(depositList: DepositDetails[], depositSource: string, depositAmount: number,filterEnabled:boolean) {

        //if isActive is selected then filter depositList based on isActive value
        //-1 is the value  selecting all deposit value
        if(!filterEnabled)
        {
            return depositList;
        }
        if (depositAmount) {
            depositList = depositList.filter(
                item =>
                    item.depositAmount>=depositAmount
            );
        }
        //if depositSource is not empty the filter deposit by depositSource
        if (depositSource) {
            depositList = depositList.filter(
                item =>
                    item.depositSource.toLowerCase().includes(
                        depositSource.toLowerCase()
                    )
            );
        }
        //return filtered list
        return depositList;
    }
}