import { TestBed } from '@angular/core/testing';

import { StudentsGroupMemberService } from './studentsGroupMember.service';

describe('StudentsGroupMemberService', () => {
  let service: StudentsGroupMemberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentsGroupMemberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
