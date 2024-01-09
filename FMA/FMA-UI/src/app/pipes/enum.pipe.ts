import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enumPipe'
})
export class EnumPipe implements PipeTransform {

  transform(value: any, enumType: any): string {
    if (value === null || value === undefined) {
      return 'Geen';
    } else {
      return enumType[value];
    }
  }
}
