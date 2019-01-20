import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSavingsParametersComponent } from './add-savings-parameters.component';

describe('AddSavingsParametersComponent', () => {
  let component: AddSavingsParametersComponent;
  let fixture: ComponentFixture<AddSavingsParametersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSavingsParametersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSavingsParametersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
