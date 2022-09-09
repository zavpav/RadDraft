import { Component, OnInit } from '@angular/core';
import { defaultColumnList } from 'src/app/distribution/doc-distribution-list-base';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';

@Component({
  selector: 'app-to-pbs-list',
  templateUrl: './to-pbs-list.component.html',
})
export class ToPbsListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getColumns(): ColumnInfo[] {
    return defaultColumnList()
  }
}
