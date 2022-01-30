import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesParentViewComponent } from './grades-parent-view.component';

describe('GradesParentViewComponent', () => {
  let component: GradesParentViewComponent;
  let fixture: ComponentFixture<GradesParentViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesParentViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GradesParentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
