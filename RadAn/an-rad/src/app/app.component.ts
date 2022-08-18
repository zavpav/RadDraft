import { Component,ViewChild  } from '@angular/core';
import { DxDataGridComponent, DxButtonComponent } from "devextreme-angular";
import themes from "devextreme/ui/themes";

import { RadSprGridComponent } from './rad-spr/rad-spr-grid/rad-spr-grid.component';

import {
  DxDataGridModule,
  DxSelectBoxModule,
} from 'devextreme-angular';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'an-rad';
  
  //@ViewChild(DxButtonComponent, { static: false }) button: DxButtonComponent;
  @ViewChild(DxButtonComponent) button!: DxButtonComponent;

  helloWorld() {
    alert('Hello world!');
  }

  changeTheme(){
      themes.ready(() => this.button.instance.repaint())
    //themes.current('generic.light');
   themes.current('generic.dark');
  }
}
