import { TestBed } from '@angular/core/testing';

import { MixedeventService } from './mixedevent.service';

describe('MixedeventService', () => {
  let service: MixedeventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MixedeventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
