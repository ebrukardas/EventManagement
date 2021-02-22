import { TestBed } from '@angular/core/testing';

import { ShowresultService } from './showresult.service';

describe('ShowresultService', () => {
  let service: ShowresultService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShowresultService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
