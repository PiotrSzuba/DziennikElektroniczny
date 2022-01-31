import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceParentViewComponent } from './attendance-parent-view.component';

describe('AttendanceParentViewComponent', () => {
  let component: AttendanceParentViewComponent;
  let fixture: ComponentFixture<AttendanceParentViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AttendanceParentViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceParentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
