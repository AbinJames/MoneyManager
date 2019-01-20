import { Time } from '@angular/common';

export class Expense{
    expenseId:number;
    isSavingsParameter:boolean;
    savingsParameterId?:number;
    parameterId?:number;
    expenseDetails:string;
    expenseDate:Date;
    expenseTime:Time;
    expenseAmount:number;
}