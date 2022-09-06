import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { 
  DxMenuModule,
  DxBulletModule,
  DxTemplateModule,
  DxDataGridModule,
  DxButtonModule,
  DxTooltipModule,
  DxPopoverModule,

  DxFormModule,
  DxTextBoxModule,
  DxDateBoxModule,
  DxTabPanelModule
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
import { HttpClientModule } from '@angular/common/http';
import { EditGridComponent } from './shared/edit-grid/edit-grid.component';

import { locale } from 'devextreme/localization';
import { ToRezervListComponentComponent } from './distribution/to-rezerv/list/to-rezerv-list.component/to-rezerv-list.component.component';
import { ToPbsListComponentComponent } from './distribution/to-pbs/list/to-pbs-list.component/to-pbs-list.component.component';
import { KuDetailListComponentComponent } from './distribution/ku-detail/list/ku-detail-list.component/ku-detail-list.component.component';
import { KuDetailEntityComponentComponent } from './distribution/ku-detail/entity/ku-detail-entity.component/ku-detail-entity.component.component';
import { ToRezervEntityComponentComponent } from './distribution/to-rezerv/entity/to-rezerv-entity.component/to-rezerv-entity.component.component';
import { ToPbsEntityComponentComponent } from './distribution/to-pbs/entity/to-pbs-entity.component/to-pbs-entity.component.component';
locale('ru')


@NgModule({
  declarations: [
    AppComponent,
    SprRadListComponent,
    SprRadEditComponent,
    HeaderComponent,
    ListGridComponent,
    NotFoundComponent,
    DocRadListComponent,
    DocRadItemComponent,
    EditGridComponent,
    ToRezervListComponentComponent,
    ToPbsListComponentComponent,
    KuDetailListComponentComponent,
    KuDetailEntityComponentComponent,
    ToRezervEntityComponentComponent,
    ToPbsEntityComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DxMenuModule,
    DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxButtonModule,
    DxTooltipModule,
    DxPopoverModule,
    DxTabPanelModule,
    DxFormModule,
    DxTextBoxModule,
    DxDateBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
