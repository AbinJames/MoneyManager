import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'SavingsParameterFilterPipe' })

export class SavingsParameterFilterPipe implements PipeTransform {
    transform(savingsParameterList: any[], savingsParameterName: string, minAmount: number, maxAmount: number, minBalance: number, maxBalance: number, filterEnabled: boolean) {
        console.log("\nsavingsParameterName " + savingsParameterName
            + "\nminAmount " + minAmount
            + "\nmaxAmount " + maxAmount
            + "\nfilterEnabled " + filterEnabled);
        //return original list if filtered button is not clicked
        if (!filterEnabled) {
            return savingsParameterList;
        }
        //if savingsParameter balance is not empty, select value satisfying balance filter
        if (minBalance || maxBalance && (minBalance <= maxBalance)) {
            savingsParameterList = savingsParameterList.filter(
                item =>
                    (maxBalance >= item.savingsParameterBalance) && (item.savingsParameterBalance >= minBalance)
            );
        }
        //if savingsParameterName is not empty the filter savingsParameter by savingsParameterName
        if (savingsParameterName) {
            savingsParameterList = savingsParameterList.filter(
                item =>
                    item.savingsParameterName.toLowerCase().includes(
                        savingsParameterName.toLowerCase()
                    )
            );
        }
        //return filtered list
        return savingsParameterList;
    }
}