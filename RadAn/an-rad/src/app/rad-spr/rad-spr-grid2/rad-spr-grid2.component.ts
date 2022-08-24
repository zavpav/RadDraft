import { Component, OnInit } from '@angular/core';
import { ColumnInfo } from 'src/app/shared/dx-column-info';

@Component({
  selector: 'app-rad-spr-grid2',
  templateUrl: './rad-spr-grid2.component.html'
})
export class RadSprGrid2Component implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  getColumns(): ColumnInfo[]{
    return [
      { caption: "id", dataField: "id", dataType:"number" },
      { caption: "Полное наименование", dataField:"fullName", dataType: "string" },
      { caption: "ИНН",           dataField: "inn"   , dataType:"string", width: 100},
      { caption: "КПП",           dataField: "kpp"   , dataType:"string", width: 100},
      { caption: "КБК",           dataField: "kbk"   , dataType:"string", width: 180},
      { caption: "Дата создания", dataField: "onDate", dataType:"date"  , width: 100, format:"dd.MM.yyyy"},
      { caption: "Дата закрытия", dataField: "toDate", dataType:"date"  , width: 100, format:"dd.MM.yyyy"}
    ]
  }
}
