import { Time } from '@angular/common';

export class Expense{
    expenseId:number;
    parameterId:number;
    expenseDetails:string;
    expenseDate:Date;
    expenseTime:Time;
    expenseAmount:number;
}