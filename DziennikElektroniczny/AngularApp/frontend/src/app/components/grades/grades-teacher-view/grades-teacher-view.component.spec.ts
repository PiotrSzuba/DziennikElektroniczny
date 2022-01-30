import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesTeacherViewComponent } from './grades-teacher-view.component';

describe('GradesTeacherViewComponent', () => {
  let component: GradesTeacherViewComponent;
  let fixture: ComponentFixture<GradesTeacherViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesTeacherViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GradesTeacherViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
