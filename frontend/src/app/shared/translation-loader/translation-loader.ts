import { TranslateLoader } from '@ngx-translate/core';
import { from, Observable } from 'rxjs';

export class AppTranslationLoader implements TranslateLoader {
  getTranslation(lang: string): Observable<any> {
    const jsonModule = import(`../../../assets/i18n/${lang}.json`).then(
      (res) => res.default
    );
    return from(jsonModule);
  }
}
