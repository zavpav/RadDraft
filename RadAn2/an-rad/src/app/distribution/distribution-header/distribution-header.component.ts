import { Component, Input, OnInit } from '@angular/core';
import { DocDistributionDocBase } from '../doc-distribution-list-base';

@Component({
  selector: 'app-distribution-header',
  templateUrl: './distribution-header.component.html',
})
export class DistributionHeaderComponent implements OnInit {

  constructor() { }

  @Input()
  entity!: DocDistributionDocBase

  testDate!: Date

  toDate(val: string | number | Date): Date {
    let v = val as Date 
    return v
  }

  ngOnInit(): void {
  }

}
