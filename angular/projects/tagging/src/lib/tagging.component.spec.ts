import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TaggingComponent } from './tagging.component';

describe('TaggingComponent', () => {
  let component: TaggingComponent;
  let fixture: ComponentFixture<TaggingComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TaggingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaggingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
