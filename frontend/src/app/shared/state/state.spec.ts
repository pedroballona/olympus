import { first } from 'rxjs/operators';
import { State } from './state';

describe('State', () => {
  it('estado inicial deve ser savo corretamente', async () => {
    const state = new State<number>(2);
    void expect(state.snapshot).toEqual(2);
    void expect(await state.state$.pipe(first()).toPromise()).toEqual(2);
  });

  it('getFirst deve recuperar o estado atual de forma assíncrona', async () => {
    const state = new State<number>(2);
    void expect(await state.getFirst().toPromise()).toEqual(2);
  });

  it('setState deve modificar o estado atual', () => {
    const spy = jasmine.createSpy();
    const state = new State<{number: number}>({number: 2});
    state.state$.subscribe(spy);
    state['setState'](draft => {
      draft.number = 3;
    });
    void expect(spy.calls.allArgs()).toEqual([
      [{number: 2}],
      [{number: 3}]
    ]);
  });

  it('forceState deve setar o estado diretamente', () => {
    const spy = jasmine.createSpy();
    const state = new State<{number: number}>({number: 2});
    state.state$.subscribe(spy);
    state['forceSetState']({number: 3});
    void expect(spy.calls.allArgs()).toEqual([
      [{number: 2}],
      [{number: 3}]
    ]);
  });
});