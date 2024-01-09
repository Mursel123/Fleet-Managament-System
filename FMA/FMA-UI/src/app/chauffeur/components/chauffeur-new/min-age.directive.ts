import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
  selector: '[minAge][ngModel]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: MinAgeDirective,
      multi: true
    }
  ]
})
export class MinAgeDirective {

  minAge: number = 18;

  validate(control: AbstractControl): ValidationErrors | null {
    if (control.value) {
      const birthDate: Date = new Date(control.value);
      const today: Date = new Date();
      const age: number = today.getFullYear() - birthDate.getFullYear();

      if (age < this.minAge) {
        return { minAge: true };
      }
    }

    return null;
  }

}
