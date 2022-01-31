import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceLessonViewComponent } from './attendance-lesson-view.component';

describe('AttendanceLessonViewComponent', () => {
  let component: AttendanceLessonViewComponent;
  let fixture: ComponentFixture<AttendanceLessonViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendanceLessonViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceLessonViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
