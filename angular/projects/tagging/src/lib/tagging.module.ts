import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { TaggingComponent } from './components/tagging.component';
import { TaggingRoutingModule } from './tagging-routing.module';

@NgModule({
  declarations: [TaggingComponent],
  imports: [CoreModule, ThemeSharedModule, TaggingRoutingModule],
  exports: [TaggingComponent],
})
export class TaggingModule {
  static forChild(): ModuleWithProviders<TaggingModule> {
    return {
      ngModule: TaggingModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<TaggingModule> {
    return new LazyModuleFactory(TaggingModule.forChild());
  }
}
