import { TestBed } from '@angular/core/testing';

import { ReadinputService } from './readinput.service';

describe('ReadinputService', () => {
  let service: ReadinputService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReadinputService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
