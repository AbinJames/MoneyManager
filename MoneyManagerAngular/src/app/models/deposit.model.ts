import { Time } from '@angular/common';
import { EntryModel } from './entry-model.model';

export class Deposit{
    depositId:number;
    depositSource:string;
    depositDate:Date;
    depositTime:Time;
    depositAmount:number;
    entryModels:EntryModel[];
}