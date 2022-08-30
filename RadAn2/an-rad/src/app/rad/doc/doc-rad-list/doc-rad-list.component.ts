import { Component, OnInit } from '@angular/core';
import { ColumnInfo } from 'src/app/shared/list-grid/list-grid.component';

@Component({
  selector: 'app-doc-rad-list',
  templateUrl: './doc-rad-list.component.html',
  styleUrls: ['./doc-rad-list.component.scss']
})
export class DocRadListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getColumns(): ColumnInfo[]{
    return [
      { caption: "Операция", dataField: "actions", width: 50 },
      { caption: "id", dataField: "id", dataType:"number" },
      { caption: "Номер документа", dataField:"docNum",      dataType: "string" },
      { caption: "Дата документа",  dataField: "docDt",      dataType: "date",   width: 100, format:"dd.MM.yyyy"},
      { caption: "Статус",          dataField: "statusName", dataType: "string", width: 100},
      { caption: "Примечание",      dataField: "descr",      dataType: "string", width: 100},
      { caption: "Пользователь",    dataField: "userName",   dataType: "string", width: 180},
    ]
  }  

}
