import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSavingsParametersComponent } from './view-savings-parameters.component';

describe('ViewSavingsParametersComponent', () => {
  let component: ViewSavingsParametersComponent;
  let fixture: ComponentFixture<ViewSavingsParametersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSavingsParametersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSavingsParametersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
