import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Subject } from 'rxjs';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent implements OnInit {

  modalTitle: string;
  modalContent: string;
  action: string = "";
  okButtonText: string;
  cancelButtonText: string;
  public onClose: Subject<boolean>;
  @ViewChild("yesButton")
  yesButton: ElementRef;
  constructor(private bsModalRef: BsModalRef) {}

  ngOnInit() {
    this.onClose = new Subject();
  }

  show(details) {
    this.modalTitle = details.title;
    this.modalContent = details.content;
    this.okButtonText = details.okButtonText ? details.okButtonText : "Yes";
    this.cancelButtonText = details.cancelButtonText
      ? details.cancelButtonText
      : "No";
    this.action = details.action ? details.action : "";
    setTimeout(() => this.yesButton.nativeElement.focus(), 500);
  }
  hide(status: string) {
    let response=false;
    if(status==='ok'){
      response=true;
    }
    this.onClose.next(response);
    this.bsModalRef.hide();
  }

}