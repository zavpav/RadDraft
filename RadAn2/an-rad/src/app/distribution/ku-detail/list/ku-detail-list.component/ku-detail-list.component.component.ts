import { Component, OnInit } from '@angular/core';
import { defaultColumnList } from 'src/app/distribution/doc-distribution-list-base';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';

@Component({
  selector: 'app-ku-detail-list.component',
  templateUrl: './ku-detail-list.component.component.html',
  styleUrls: ['./ku-detail-list.component.component.scss']
})
export class KuDetailListComponentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getColumns(): ColumnInfo[] {
    return defaultColumnList()
  }

}
