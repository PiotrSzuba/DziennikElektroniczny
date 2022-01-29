import { TestBed } from '@angular/core/testing';

import { StudentsGroupService } from './studentsGroup.service';

describe('StudentsGroupService', () => {
  let service: StudentsGroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentsGroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
