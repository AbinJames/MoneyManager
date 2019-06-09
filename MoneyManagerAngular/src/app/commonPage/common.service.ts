import { Injectable } from '@angular/core';
import { BsModalService } from "ngx-bootstrap";
import { Observable } from "rxjs";
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor(private modalService: BsModalService) { }

  public showConfirmation(details): Observable<any> {
    const modal = this.modalService.show(ConfirmModalComponent);
    (<ConfirmModalComponent>modal.content).show(details);
    let observable = Observable.create(observer => {
      (<ConfirmModalComponent>modal.content).onClose.subscribe(result => {
        observer.next(result);
      });
    });

    return observable;
  }
}