import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'ExpenseFilterPipe' })

export class ExpenseFilterPipe implements PipeTransform {
    transform(expenseList: any[], expenseStartDate: Date, expenseEndDate: Date, expenseDetails: string, minAmount: number, maxAmount: number, isSavingsParameter: number, parameterId: number, filterEnabled: boolean) {
        console.log("expenseStartDate " + expenseStartDate
            + "\nexpenseEndDate " + expenseEndDate
            + "\nexpenseDetails " + expenseDetails
            + "\nminAmount " + minAmount
            + "\nmaxAmount " + maxAmount
            + "\nfilterEnabled " + filterEnabled);
        //return original list if filtered button is not clicked
        if (!filterEnabled) {
            return expenseList;
        }

        if (isSavingsParameter && isSavingsParameter == -1) {
            return expenseList;
        }

        //if expense date is not empty, select value satisfying date range filter
        if (expenseStartDate || expenseEndDate && (expenseStartDate <= expenseEndDate)) {
            expenseList = expenseList.filter(
                item =>
                    new Date(expenseEndDate).getDate() >= new Date(item.expenseDate).getDate()
                    && new Date(item.expenseDate).getDate() >= new Date(expenseStartDate).getDate()
            );
        }

        //if expense amount is not empty, select value satisfying amount filter
        if (minAmount || maxAmount && (minAmount <= maxAmount)) {
            expenseList = expenseList.filter(
                item =>
                    (maxAmount >= item.expenseAmount) && (item.expenseAmount >= minAmount)
            );
        }
        //if expenseDetails is not empty the filter expense by expenseDetails
        if (expenseDetails) {
            expenseList = expenseList.filter(
                item =>
                    item.expenseDetails.toLowerCase().includes(
                        expenseDetails.toLowerCase()
                    )
            );
        }

        //if expenseDetails is not empty the filter expense by expenseDetails
        if (isSavingsParameter && isSavingsParameter != -1) {
            expenseList = expenseList.filter(
                item =>
                    item.isSavingsParameter == (isSavingsParameter == 1 ? true : false)
            );
        }

        if (parameterId && isSavingsParameter == 0) {
            expenseList = expenseList.filter(
                item =>
                    item.parameterId == parameterId
            );
        }

        if (parameterId && isSavingsParameter == 1) {
            expenseList = expenseList.filter(
                item =>
                    item.savingsParameterId == parameterId
            );
        }
        //return filtered list
        return expenseList;
    }
}