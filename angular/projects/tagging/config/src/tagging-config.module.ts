import { ModuleWithProviders, NgModule } from '@angular/core';
import { TAGGING_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class TaggingConfigModule {
  static forRoot(): ModuleWithProviders<TaggingConfigModule> {
    return {
      ngModule: TaggingConfigModule,
      providers: [TAGGING_ROUTE_PROVIDERS],
    };
  }
}
