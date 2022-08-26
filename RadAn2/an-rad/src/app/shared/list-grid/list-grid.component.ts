import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';

//import DataSource from 'devextreme/data/data_source';
import CustomStore from "devextreme/data/custom_store";
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

import Tooltip from "devextreme/ui/tooltip";

// Описание колонки для грида devextreme
export interface ColumnInfo {
  caption: string;
  dataField: string;
  dataType?: string;
  width?: number;
  format?: string;
}

// Внешняя информация по действию со строкой
export interface ActionInfo{
  // Имя операции
  operation: string;
  // Куда пересылать
  endpoint?: string;
  // Каким рисунком отображать
  glyph?: string;
  // Какую подсказку писать
  tooltip?: string
}

interface CurrentTooltipInfo {
  target: string
  tooltip: string
  rowId: string
}

interface InternalActionInfo{
  trackBy: string;
  id: string;
  objId: string;
  glyph: string;
  tooltip: string;
  href?: string;
}

@Component({
  selector: 'app-list-grid',
  templateUrl: './list-grid.component.html',
  styleUrls: ['./list-grid.component.scss']
})
export class ListGridComponent implements OnInit {

  dataSource!: CustomStore<any, any>;
  @Input() serverController!: string;
  
  @Input() mainRouting!: string;
  getMainRoutingInfo(): string[] {
    let routing = this.mainRouting;
    if (routing.startsWith('/')){
      routing = routing.substring(1)
    }
    return ['/'].concat(routing.split('/'))
  }

  @Input() columns!: ColumnInfo[];
  getColumnsCache!: ColumnInfo[];
  getColumns(): ColumnInfo[]{
    if (this.getColumnsCache)
      return this.getColumnsCache
    this.getColumnsCache = this.columns.filter(x => x.dataField != "id")
    return this.getColumnsCache
  }


  getRouteForAction(id: number, actionInfo: InternalActionInfo): Array<string> {
    var routeInfo: string[] = []
    if (!!actionInfo.href){
      routeInfo.push(actionInfo.href)
    } else {
      routeInfo = this.getMainRoutingInfo();
      routeInfo.push('item')
      routeInfo.push(id.toString())
    }
    return routeInfo;
  }





  currentTooltip?: CurrentTooltipInfo;

  showOperationTooltip($event : any, action: InternalActionInfo){
    console.log("showOperationTooltip")
    if (!this.currentTooltip || this.currentTooltip.target != $event.target.id){
      this.currentTooltip = {
        target: $event.target.id,
        tooltip: action.tooltip + " " + $event.target.id,
        rowId: action.objId

      }
    }

  }
  overOperationTooltip($event : any){
    console.log('Over: ' + $event)
    // this.currentTooltip = {
    //   target: $event.currentTarget,
    //   tooltip: "Тултип " + $event.currentTarget
    // }

  }
  moveOperationTooltip($event : any){
    console.log('Move: ' + $event)
  }
  hideOperationTooltip($event : any){
    this.currentTooltip = undefined;
  }
  target!:string;
  tooltipshowing($event: any){

  }
  tooltipshown($event: any){

  }

  trackByFn(index: number, actionInfo: InternalActionInfo){
    return actionInfo.trackBy
  }

  parsedActions(column: any): InternalActionInfo[] {
    const data = column.data;
    const actionInfos = data.actions as ActionInfo[];

    if (!!actionInfos){
      const ops: InternalActionInfo[] = []
      actionInfos.forEach(e => {
        ops.push(this.parseOperation(data.id, e))
      })

      return ops;
    }
    else{
      return []
    }
  }

  private parseOperation(dataId: number, op: ActionInfo): InternalActionInfo {
    //🖌🛠
    //Misc Symbols and Pictographs
    if (op.operation == "edit"){
      return {
        objId: dataId.toString(),
        trackBy: op.operation+dataId,
        id: op.operation,
        glyph: "🖹",
        tooltip: "Редактирование",
      }
    }
    else if(op.operation == "delete"){
      return {
        objId: dataId.toString(),
        trackBy: op.operation+dataId,
        id: op.operation,
        glyph: "🗑",
        tooltip: "Удаление",
      }
    }
    else {
      return {
        objId: dataId.toString(),
        trackBy: op.operation+dataId,
        id: op.operation,
        glyph: op.glyph ?? "err",
        tooltip: op.tooltip ?? "Непонятно",
        href: op.endpoint ?? "notfound"
      }
    }

  }

  // Проверка на то что доступны "визуальные операции" типа сортировки, фильтров и т.д. и тп.
  // Для "действий" это запрещено.
  allowVisualOperation(c: ColumnInfo){
    return c.dataField !== "actions";
  }

  // @ViewChild('tooltip') tooltip!: any;
  
  // hoverChange($event:any){
  //   if ($event.rowType === "data" && $event.column.dataField === "actions") {
  //     console.log('cellHover' + $event)

  //     const tt =this.tooltip.instance as  Tooltip
  //     // if (!!this.currentTooltip && !!this.currentTooltip?.target){
  //     //   tt.show(this.currentTooltip.target)
  //     // }else{
  //     //   this.tooltip.instance.show()
  //     // }
      
  //   }
  // }

  customizeTooltip = (pointsInfo: any) => {
    console.log('customizeTooltip ' + pointsInfo)
    return
    (
      {     text: 'asdfasdf' })
  };
  
  
  // Получить полный endpoint для получения данных
  private getFullListEndpoint(): string{
    return environment.mainEndpoint + this.serverController + "/List";
  }

  ngOnInit(): void {
    console.log("Default grid " + this.getFullListEndpoint())
    let stor = AspNetData.createStore({
        key: 'id',
        loadUrl: this.getFullListEndpoint(),
        onBeforeSend: (operation: string, ajaxSettings : {data? : any}) => {
            if (operation == "load")
            {
  //                            cntx.fillObjAsField(ajaxSettings.data);
            }
        },
        onLoaded: (result: Array<any>) => {
            return result
        },
        loadMode: "processed"
    });
    this.dataSource = stor;
  }
}
