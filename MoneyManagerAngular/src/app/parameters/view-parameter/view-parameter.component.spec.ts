import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewParameterComponent } from './view-parameter.component';

describe('ViewParameterComponent', () => {
  let component: ViewParameterComponent;
  let fixture: ComponentFixture<ViewParameterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewParameterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewParameterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
