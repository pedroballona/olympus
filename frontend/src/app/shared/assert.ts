export function assert(condition: any): asserts condition {
  if (!condition) {
    throw new Error('Assertion error');
  }
}
