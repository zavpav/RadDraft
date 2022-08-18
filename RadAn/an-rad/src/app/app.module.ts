import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {   DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxButtonModule 
} from 'devextreme-angular';




import { RadSprGridComponent } from './rad-spr/rad-spr-grid/rad-spr-grid.component';
import { RadSprService } from './rad-spr/rad-spr-service'


// import "devextreme/dist/css/dx.light.css";
// import "devextreme/dist/css/dx.material.blue.dark.css"
import themes from 'devextreme/ui/themes';

themes.current("softblue")


@NgModule({
  declarations: [
    AppComponent,
    RadSprGridComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxDataGridModule,
    DxBulletModule,
    DxTemplateModule,
    DxButtonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
