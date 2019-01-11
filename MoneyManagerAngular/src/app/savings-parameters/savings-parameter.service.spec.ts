import { TestBed } from '@angular/core/testing';

import { SavingsParameterService } from './savings-parameter.service';

describe('SavingsParameterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SavingsParameterService = TestBed.get(SavingsParameterService);
    expect(service).toBeTruthy();
  });
});
