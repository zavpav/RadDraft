import { Component, OnInit } from '@angular/core';
import { defaultColumnList } from 'src/app/distribution/doc-distribution-list-base';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';

@Component({
  selector: 'app-to-rezerv-list.component',
  templateUrl: './to-rezerv-list.component.component.html',
  styleUrls: ['./to-rezerv-list.component.component.scss']
})
export class ToRezervListComponentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getColumns(): ColumnInfo[] {
    return defaultColumnList()
  }
}
