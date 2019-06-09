import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'ParameterFilterPipe' })

export class ParameterFilterPipe implements PipeTransform {
    transform(parameterList: any[], parameterName: string, minAmount: number, maxAmount: number, minBalance: number, maxBalance: number, filterEnabled: boolean) {
        console.log("\nparameterName " + parameterName
            + "\nminAmount " + minAmount
            + "\nmaxAmount " + maxAmount
            + "\nfilterEnabled " + filterEnabled);
        //return original list if filtered button is not clicked
        if (!filterEnabled) {
            return parameterList;
        }

        //if parameter amount is not empty, select value satisfying amount filter
        if (minAmount || maxAmount && (minAmount <= maxAmount)) {
            parameterList = parameterList.filter(
                item =>
                    (maxAmount >= item.parameterAmount) && (item.parameterAmount >= minAmount)
            );
        }
        //if parameter balance is not empty, select value satisfying balance filter
        if (minBalance || maxBalance && (minBalance <= maxBalance)) {
            parameterList = parameterList.filter(
                item =>
                    (maxBalance >= item.parameterBalance) && (item.parameterBalance >= minBalance)
            );
        }
        //if parameterName is not empty the filter parameter by parameterName
        if (parameterName) {
            parameterList = parameterList.filter(
                item =>
                    item.parameterName.toLowerCase().includes(
                        parameterName.toLowerCase()
                    )
            );
        }
        //return filtered list
        return parameterList;
    }
}