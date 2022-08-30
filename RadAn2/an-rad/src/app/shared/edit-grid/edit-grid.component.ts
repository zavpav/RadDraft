import { Component, Input, OnInit } from '@angular/core';
import { HtmlEditorFormat } from 'devextreme/ui/html_editor';
import { ColumnInfo } from '../list-grid/list-grid.component';

@Component({
  selector: 'app-edit-grid',
  templateUrl: './edit-grid.component.html',
  styleUrls: ['./edit-grid.component.scss']
})
export class EditGridComponent implements OnInit {

  constructor() { }
  @Input() dataSource!: any[];
  @Input() columns!: ColumnInfo[];

  getColumnsCache!: ColumnInfo[];
  getColumns(): ColumnInfo[]{
    if (this.getColumnsCache)
      return this.getColumnsCache
    this.getColumnsCache = this.columns.filter(x => x.dataField != "id")
    return this.getColumnsCache
  }


  ngOnInit(): void {
    this.columns.forEach(c => {
      if (c.dataType === "date" && !c.format){
        c.format = "dd.MM.yyyy"
      }
    });
  }

  onFocusedCellChanging(e:any) {
    e.isHighlighted = true;
  }

  onEditorPreparing($event: {
    allowEditing: boolean;
    cancel: boolean;
    dataType: string;
    editorName: string;
    editorElement: HTMLElement;
    editorOptions: any;
    name: string;
    readonly: boolean;
    row: {cells: any; data: any; dataIndex: number; isEditing: boolean; key: any; rowIndex: number; rowType: string; values: any[]};
    setCellValue: Function;
    setValue: Function;
    parseValue: Function;
    visible: boolean;
  }){
    // if (!this.canBeEdit($event.column.dataField, $event.row.data)){
    //   //$event.cancel = true;
    //   $event.editorOptions.disabled = true;
    //   return;
    // }


    console.log('onEditorPreparing', $event)
  }

  onEditorPrepared($event: {
    allowEditing: boolean;
    cancel: boolean;
    dataType: string;
    editorName: string;
    editorElement: HTMLElement;
    editorOptions: any;
    name: string;
    readonly: boolean;
    row: {cells: any; data: any; dataIndex: number; isEditing: boolean; key: any; rowIndex: number; rowType: string; values: any[]};
    setCellValue: Function;
    setValue: Function;
    parseValue: Function;
    visible: boolean;
  }){
    if ($event.row.rowType == 'data' && ($event.dataType == "string" || $event.dataType == "date")){
      const inps = $event.editorElement.querySelectorAll('input:not([type="hidden"])')
      if (inps.length != 1){
        console.warn('onEditorPrepared Найдено странное количество элементов ввода', inps)
      } else {
        inps.forEach(x => (x as HTMLInputElement).style.backgroundColor='gold')
      }

      $event.editorElement.style.backgroundColor = 'red'
    }
    console.log('onEditorPrepared', $event)
  }

  onCellPrepared($event: {
    rowType: string; 
    columnIndex: number;
    rowIndex: number;

    data: any
    value: any; 
    values: any[];
    text: string;
    
    column: any; 
    cellElement: HTMLElement; 
    summary?: string;
    isAltRow: boolean;
    isEditing: boolean;
  }){
    // Если isEditing==true при редактировании чисел или строк - не виден, так как оно скрыто собственно редактором
    if ($event.rowType == "data"){
      if (this.canBeEdit($event.column.dataField, $event.data)){
        $event.cellElement.style.backgroundColor = "yellow"
      }
    }
    
  //  console.log('CellShow', $event)
  }

  onEditingStart($event: any){
    $event.cancel = !this.canBeEdit($event.column.dataField, $event.data)
  }

  canBeEdit(dataField: string, data: any): boolean {
    if (data["id"].toString().charAt(5) % 2 == 0){
      return true
    }
    return false;
  }


  contentReady($event:any){
    console.log("Content Ready", $event)
  }
}
