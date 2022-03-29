import { Component, OnInit } from '@angular/core';
import { TaggingService } from '../services/tagging.service';

@Component({
  selector: 'lib-tagging',
  template: ` <p>tagging works!</p> `,
  styles: [],
})
export class TaggingComponent implements OnInit {
  constructor(private service: TaggingService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
