import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateStudentGroupDialogComponent } from './create-student-group-dialog.component';

describe('CreateStudentGroupDialogComponent', () => {
  let component: CreateStudentGroupDialogComponent;
  let fixture: ComponentFixture<CreateStudentGroupDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateStudentGroupDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateStudentGroupDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
