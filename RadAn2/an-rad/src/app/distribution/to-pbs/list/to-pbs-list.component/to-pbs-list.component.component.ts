import { Component, OnInit } from '@angular/core';
import { defaultColumnList } from 'src/app/distribution/doc-distribution-list-base';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';

@Component({
  selector: 'app-to-pbs-list.component',
  templateUrl: './to-pbs-list.component.component.html',
  styleUrls: ['./to-pbs-list.component.component.scss']
})
export class ToPbsListComponentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getColumns(): ColumnInfo[] {
    return defaultColumnList()
  }
}
