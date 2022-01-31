import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceStudentViewComponent } from './attendance-student-view.component';

describe('AttendanceStudentViewComponent', () => {
  let component: AttendanceStudentViewComponent;
  let fixture: ComponentFixture<AttendanceStudentViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendanceStudentViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceStudentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
