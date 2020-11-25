import { guid } from './';

export class Guid {
    static empty: guid = '00000000-0000-0000-0000-000000000000';

    static isEmpty = (value: Guid) => value === Guid.empty;
    static isValid = (value: string | guid): boolean =>
        Guid.validator.test(value);
    static newGuid = (): guid =>
        [
            Guid.generateGuidSegment(2),
            Guid.generateGuidSegment(1),
            Guid.generateGuidSegment(1),
            Guid.generateGuidSegment(1),
            Guid.generateGuidSegment(3),
        ].join('-');

    private static validator = /^[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}$/i;
    private static generateGuidSegment(count: number): string {
        let out = '';
        for (let i = 0; i < count; i++) {
            // tslint:disable-next-line:no-bitwise
            out += (((1 + Math.random()) * 0x10000) | 0)
                .toString(16)
                .substring(1);
        }
        return out;
    }
}
