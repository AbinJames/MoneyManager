import { Pipe, PipeTransform } from '@angular/core';
import { Deposit } from '../models/deposit.model';

@Pipe({ name: 'DepositFilterPipe' })

export class DepositFilterPipe implements PipeTransform {
    transform(depositList: Deposit[], depositStartDate: Date, depositEndDate: Date, depositSource: string, minAmount: number, maxAmount: number, filterEnabled: boolean) {
        console.log("depositStartDate " + depositStartDate
            + "\ndepositEndDate " + depositEndDate
            + "\ndepositSource " + depositSource
            + "\nminAmount " + minAmount
            + "\nmaxAmount " + maxAmount
            + "\nfilterEnabled " + filterEnabled);
        //return original list if filtered button is not clicked
        if (!filterEnabled) {
            return depositList;
        }

        //if deposit date is not empty, select value satisfying date range filter
        if (depositStartDate || depositEndDate && (depositStartDate <= depositEndDate)) {
            depositList = depositList.filter(
                item =>
                    new Date(depositEndDate).getDate() >= new Date(item.depositDate).getDate()
                    && new Date(item.depositDate).getDate() >= new Date(depositStartDate).getDate()
            );
        }

        //if deposit amount is not empty, select value satisfying amount filter
        if (minAmount || maxAmount && (minAmount <= maxAmount)) {
            depositList = depositList.filter(
                item =>
                    (maxAmount >= item.depositAmount) && (item.depositAmount >= minAmount)
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