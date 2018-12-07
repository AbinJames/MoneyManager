import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDepositComponent } from './view-deposit.component';

describe('ViewDepositComponent', () => {
  let component: ViewDepositComponent;
  let fixture: ComponentFixture<ViewDepositComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDepositComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDepositComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
