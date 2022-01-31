import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceSubjectViewComponent } from './attendance-subject-view.component';

describe('AttendanceSubjectViewComponent', () => {
  let component: AttendanceSubjectViewComponent;
  let fixture: ComponentFixture<AttendanceSubjectViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendanceSubjectViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceSubjectViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
