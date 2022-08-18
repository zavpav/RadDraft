import { Injectable } from '@angular/core';
import 'devextreme/data/odata/store';
import DataSource from 'devextreme/data/data_source';

import { HttpClient } from '@angular/common/http';


@Injectable()
export class RadSprService {
  constructor(private http: HttpClient){

  }

  getDataSource() {
    return new DataSource({
      store: {
        type: 'odata',
        url: 'https://js.devexpress.com/Demos/SalesViewer/odata/DaySaleDtoes',
        key: 'Id',
        beforeSend(request) {
          request.params.startDate = '2020-05-10';
          request.params.endDate = '2020-05-15';
        },
      },
    });
  }
}