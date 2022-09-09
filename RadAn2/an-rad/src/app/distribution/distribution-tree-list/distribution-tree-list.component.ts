import { Component, Input, OnInit } from '@angular/core';
import { DocDistributionRowBase } from '../doc-distribution-list-base';

@Component({
  selector: 'app-distribution-tree-list',
  templateUrl: './distribution-tree-list.component.html',
})
export class DistributionTreeListComponent implements OnInit {

  constructor() { }


  @Input() rows!: DocDistributionRowBase[]

  @Input() year!: number

  ngOnInit(): void {
    if (!this.year){
      this.year = 2000
    }

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
    if ($event.row.rowType == 'data' && ($event.dataType == "string" || $event.dataType == "date"|| $event.dataType == "number")){
      const inps = $event.editorElement.querySelectorAll('input:not([type="hidden"])')
      if (inps.length != 1){
        console.warn('onEditorPrepared Найдено странное количество элементов ввода', inps)
      } else {
        $event.editorOptions.format = "#,##0.00"
        inps.forEach(x => (x as HTMLInputElement).style.backgroundColor='gold')
      }

      $event.editorElement.style.backgroundColor = 'red'
    }
    console.log('onEditorPrepared', $event)
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
    if ($event.row.rowType == 'data' && ($event.dataType == "string" || $event.dataType == "date"|| $event.dataType == "number")){
      const inps = $event.editorElement.querySelectorAll('input:not([type="hidden"])')
      if (inps.length != 1){
        console.warn('onEditorPrepared Найдено странное количество элементов ввода', inps)
      } else {
        $event.editorOptions.format = "#,##0.00"
        inps.forEach(x => (x as HTMLInputElement).style.backgroundColor='gold')
      }

      $event.editorElement.style.backgroundColor = 'red'
    }
    console.log('onEditorPrepared', $event)
  }


  onEditingStart($event: any){
    $event.cancel = !this.canBeEdit($event.column.dataField, $event.data)
  }

  canBeEdit(dataField: string, data: any): boolean {
    if (!dataField.startsWith("sm")){
      return false
    }
    
    if (data["id"].toString().charAt(5) % 2 == 0){
      return true
    }
    return false;
  }
  numberFormatter($event:any){
    console.log("aaa", $event)
  }
}
