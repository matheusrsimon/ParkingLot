export class StringHelper {
  private constructor() { }

  public static trim(target: string, value: string) {
    value = value.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    return target.replace(new RegExp(`^${value}+|${value}+$`, 'g'), '');
  }

  public static random(length: number): string {
    let result: string = '';
    let characters: string = 'ABCDEFGHIJKLMNOPQRSTUVXYWZ0123456789';

    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * characters.length));
    }

    return result;
  }
}
