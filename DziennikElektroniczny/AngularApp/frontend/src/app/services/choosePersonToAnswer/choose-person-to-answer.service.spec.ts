import { TestBed } from '@angular/core/testing';

import { ChoosePersonToAnswerService } from './choose-person-to-answer.service';

describe('ChoosePersonToAnswerService', () => {
  let service: ChoosePersonToAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChoosePersonToAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
