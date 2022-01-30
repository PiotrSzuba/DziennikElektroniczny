import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesSubjectViewComponent } from './grades-subject-view.component';

describe('GradesSubjectViewComponent', () => {
  let component: GradesSubjectViewComponent;
  let fixture: ComponentFixture<GradesSubjectViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesSubjectViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GradesSubjectViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
