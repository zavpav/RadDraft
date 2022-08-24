import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { 
  DxMenuModule,
  DxBulletModule,
  DxTemplateModule,
  DxDataGridModule,
  DxButtonModule,
  DxTooltipModule,
  DxPopoverModule
} from 'devextreme-angular';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SprRadListComponent } from './rad/spr/spr-rad-list/spr-rad-list.component';
import { SprRadEditComponent } from './rad/spr/spr-rad-edit/spr-rad-edit.component';
import { HeaderComponent } from './shared/header/header.component';
import { ListGridComponent } from './shared/list-grid/list-grid.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { DocRadListComponent } from './rad/doc/doc-rad-list/doc-rad-list.component';
import { DocRadItemComponent } from './rad/doc/doc-rad-item/doc-rad-item.component';

@NgModule({
  declarations: [
    AppComponent,
    SprRadListComponent,
    SprRadEditComponent,
    HeaderComponent,
    ListGridComponent,
    NotFoundComponent,
    DocRadListComponent,
    DocRadItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxMenuModule,
    DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxButtonModule,
    DxTooltipModule,
    DxPopoverModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
