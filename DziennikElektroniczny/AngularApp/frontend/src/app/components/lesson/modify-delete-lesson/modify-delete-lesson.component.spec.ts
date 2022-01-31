import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyDeleteLessonComponent } from './modify-delete-lesson.component';

describe('ModifyDeleteLessonComponent', () => {
  let component: ModifyDeleteLessonComponent;
  let fixture: ComponentFixture<ModifyDeleteLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifyDeleteLessonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyDeleteLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
