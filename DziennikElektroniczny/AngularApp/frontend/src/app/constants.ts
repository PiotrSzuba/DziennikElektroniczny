export const GRADE_VALUES = [
  '+',
  '-',
  '1',
  '1+',
  '2-',
  '2',
  '2+',
  '3-',
  '3',
  '3+',
  '4-',
  '4',
  '4+',
  '5-',
  '5',
  '5+',
  '6-',
  '6',
];

export class GradeValue {
  constructor(
    public value: string,
    public numeric: number,
    public wage: number = 1
  ) {}
}

export const GRADE_VALUES_NUMERIC_AND_WAGE = [
  new GradeValue('+', 0, 0),
  new GradeValue('-', 0, 0),
  new GradeValue('1', 1, 1),
  new GradeValue('1+', 1.5, 1),
  new GradeValue('2-', 1.75, 1),
  new GradeValue('2', 2, 1),
  new GradeValue('2+', 2.5, 1),
  new GradeValue('3-', 2.75, 1),
  new GradeValue('3', 3, 1),
  new GradeValue('3+', 3.5, 1),
  new GradeValue('4-', 3.75, 1),
  new GradeValue('4', 4, 1),
  new GradeValue('4+', 4.5, 1),
  new GradeValue('5-', 4.75, 1),
  new GradeValue('5', 5, 1),
  new GradeValue('5+', 5.5, 1),
  new GradeValue('6-', 5.75, 1),
  new GradeValue('6', 6, 1),
];
