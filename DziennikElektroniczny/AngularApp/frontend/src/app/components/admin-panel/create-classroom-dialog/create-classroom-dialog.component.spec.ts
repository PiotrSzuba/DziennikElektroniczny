import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateClassroomDialogComponent } from './create-classroom-dialog.component';

describe('CreateClassroomDialogComponent', () => {
  let component: CreateClassroomDialogComponent;
  let fixture: ComponentFixture<CreateClassroomDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateClassroomDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateClassroomDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
