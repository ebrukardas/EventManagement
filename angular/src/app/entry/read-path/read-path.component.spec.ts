import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadPathComponent } from './read-path.component';

describe('ReadPathComponent', () => {
  let component: ReadPathComponent;
  let fixture: ComponentFixture<ReadPathComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReadPathComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadPathComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
