import { Component, Input, OnInit } from '@angular/core';

//import DataSource from 'devextreme/data/data_source';
import CustomStore from "devextreme/data/custom_store";
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { ColumnInfo } from 'src/app/shared/dx-column-info';

@Component({
  selector: 'app-list-grid',
  templateUrl: './list-grid.component.html',
})
export class ListGridComponent implements OnInit {
  
  dataSource!: CustomStore<any, any>;
  @Input() endpoint!: string;

  @Input() columns!: ColumnInfo[];
  getColumnsCache!: ColumnInfo[];
  getColumns(): ColumnInfo[]{
    if (this.getColumnsCache)
      return this.getColumnsCache
    this.getColumnsCache = this.columns.filter(x => x.dataField != "id")
    return this.getColumnsCache
  }

  customizeTooltip = (pointsInfo: any) => ({ text: `${parseInt(pointsInfo.originalValue)}%` });
  
  ngOnInit(): void {
    console.log("Default grid " + this.endpoint)
    let stor = AspNetData.createStore({
        key: 'id',
        loadUrl: 'https://localhost:7234/' + this.endpoint,
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
