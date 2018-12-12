import { Pipe, PipeTransform } from '@angular/core';
import { Expense } from '../models/expense.model';

@Pipe({ name: 'ExpenseFilterPipe' })

export class ExpenseFilterPipe implements PipeTransform {
    transform(expenseList: Expense[], expenseStartDate: Date, expenseEndDate: Date, expenseDetails: string, minAmount: number, maxAmount: number, filterEnabled: boolean) {
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
        //return filtered list
        return expenseList;
    }
}