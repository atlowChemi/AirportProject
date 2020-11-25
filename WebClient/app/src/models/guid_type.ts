class GuidFlavoring<FlavorT> {
    // tslint:disable-next-line: variable-name
    _type?: FlavorT;
}
/** A **guid** type, based on **string** */
type GuidFlavor<T, FlavorT> = T & GuidFlavoring<FlavorT>;
export type guid = GuidFlavor<string, 'guid'>;
