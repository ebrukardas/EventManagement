import { TestBed } from '@angular/core/testing';

import { SyntheticeventService } from './syntheticevent.service';

describe('SyntheticeventService', () => {
  let service: SyntheticeventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SyntheticeventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
