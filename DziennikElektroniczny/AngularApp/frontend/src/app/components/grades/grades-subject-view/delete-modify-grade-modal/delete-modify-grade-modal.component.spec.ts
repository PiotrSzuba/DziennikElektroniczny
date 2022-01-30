import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteModifyGradeModalComponent } from './delete-modify-grade-modal.component';

describe('DeleteModifyGradeModalComponent', () => {
  let component: DeleteModifyGradeModalComponent;
  let fixture: ComponentFixture<DeleteModifyGradeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteModifyGradeModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteModifyGradeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
