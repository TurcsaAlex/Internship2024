import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function notInListValidator(list: string[]): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (list.includes(value)) {
      return { notInList: true };
    }

    return null;
  };
}
