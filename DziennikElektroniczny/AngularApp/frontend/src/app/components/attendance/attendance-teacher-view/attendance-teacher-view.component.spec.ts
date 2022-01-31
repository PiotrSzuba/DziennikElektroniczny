import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceTeacherViewComponent } from './attendance-teacher-view.component';

describe('AttendanceTeacherViewComponent', () => {
  let component: AttendanceTeacherViewComponent;
  let fixture: ComponentFixture<AttendanceTeacherViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendanceTeacherViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceTeacherViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
