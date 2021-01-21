import { Draft, produce } from 'immer';
import { BehaviorSubject, Observable } from 'rxjs';
import { first } from 'rxjs/operators';

export class State<T> {
  private stateSubject: BehaviorSubject<T>;
  readonly state$: Observable<T>;

  get snapshot(): T {
    return this.stateSubject.value;
  }

  constructor(initialState?: T) {
    const state = {... initialState};
    this.stateSubject = new BehaviorSubject<T>(state as T);
    this.state$ = this.stateSubject.asObservable();
  }

  protected setState(callBack: (draft: Draft<T>) => void): T {
    const newState = produce(this.snapshot, callBack);
    this.stateSubject.next(newState);
    return newState;
  }

  protected forceSetState(state: T): void {
    this.stateSubject.next(state);
  }

  getFirst(): Observable<T> {
    return this.state$.pipe(first());
  }
}
