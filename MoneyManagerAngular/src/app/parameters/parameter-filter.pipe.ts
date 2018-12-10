import { Pipe, PipeTransform } from '@angular/core';
import { AmountSplitParameter } from '../models/amount-split-parameters.model';

@Pipe({ name: 'ParameterFilterPipe' })

export class ParameterFilterPipe implements PipeTransform {
    transform(parameterList: AmountSplitParameter[], parameterName: string, minAmount: number, maxAmount: number, filterEnabled: boolean) {
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