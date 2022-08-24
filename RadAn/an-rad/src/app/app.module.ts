import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { 
    DxMenuModule,
    DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxButtonModule 
} from 'devextreme-angular';




import { ListGridComponent } from './components/list-grid/list-grid.component';
import { RadSprGrid2Component } from './rad-spr/rad-spr-grid2/rad-spr-grid2.component';
import { RadSprGridComponent } from './rad-spr/rad-spr-grid/rad-spr-grid.component';
import { RadSprService } from './rad-spr/rad-spr-service'


// import "devextreme/dist/css/dx.light.css";
// import "devextreme/dist/css/dx.material.blue.dark.css"
import themes from 'devextreme/ui/themes';
import { RadListComponent } from './rad-spr/rad-list.component';
import { HeaderComponent } from './shared/header/header.component';
import { RadItemComponent } from './rad-spr/rad-item/rad-item.component';

themes.current("softblue")


@NgModule({
  declarations: [
    AppComponent,
    RadSprGridComponent,
    ListGridComponent,
    RadSprGrid2Component,
    RadListComponent,
    HeaderComponent,
    RadItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxMenuModule,
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
