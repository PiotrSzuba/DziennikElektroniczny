import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesStudentViewComponent } from './grades-student-view.component';

describe('GradesStudentViewComponent', () => {
  let component: GradesStudentViewComponent;
  let fixture: ComponentFixture<GradesStudentViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesStudentViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GradesStudentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
