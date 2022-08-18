import { Component, Input, OnInit } from '@angular/core';

import { RadSprService } from '../rad-spr-service';

//import DataSource from 'devextreme/data/data_source';
import CustomStore from "devextreme/data/custom_store";
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { ISprRad } from '../spr-rad';


@Component({
  selector: 'app-rad-spr-grid',
  templateUrl: './rad-spr-grid.component.html',
  providers: [RadSprService],
})
export class RadSprGridComponent implements OnInit {
  
  dataSource!: CustomStore<ISprRad, number>;
  @Input() endpoint!: string;

  customizeTooltip = (pointsInfo: any) => ({ text: `${parseInt(pointsInfo.originalValue)}%` });
  
  ngOnInit(): void {
    let stor = AspNetData.createStore({
        key: 'id',
        loadUrl: 'https://localhost:7234/' + this.endpoint,
        onBeforeSend: (operation: string, ajaxSettings : {data? : any}) => {
            if (operation == "load")
            {
  //                            cntx.fillObjAsField(ajaxSettings.data);
            }
        },
        onLoaded: (result: Array<ISprRad>) => {
            return result
        },
        loadMode: "processed"
    });
    this.dataSource = stor;
  }

}
