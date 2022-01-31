import { TestBed } from '@angular/core/testing';

import { StudentGroupMemberService } from './student-group-member.service';

describe('StudentGroupMemberService', () => {
  let service: StudentGroupMemberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentGroupMemberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
