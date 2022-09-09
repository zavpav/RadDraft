import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { 
  DxMenuModule,
  DxBulletModule,
  DxTemplateModule,
  DxDataGridModule,
  DxTreeListModule,
  DxButtonModule,
  DxTooltipModule,
  DxPopoverModule,

  DxFormModule,
  DxTextBoxModule,
  DxNumberBoxModule,
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
import { ToRezervListComponent } from './distribution/to-rezerv/list/to-rezerv-list/to-rezerv-list.component';
import { ToPbsListComponent } from './distribution/to-pbs/list/to-pbs-list/to-pbs-list.component';
import { KuDetailListComponent } from './distribution/ku-detail/list/ku-detail-list/ku-detail-list.component';
import { KuDetailEntityComponent } from './distribution/ku-detail/entity/ku-detail-entity/ku-detail-entity.component';
import { ToRezervEntityComponent } from './distribution/to-rezerv/entity/to-rezerv-entity/to-rezerv-entity.component';
import { ToPbsEntityComponent } from './distribution/to-pbs/entity/to-pbs-entity/to-pbs-entity.component';
import { DistributionHeaderComponent } from './distribution/distribution-header/distribution-header.component';
import { DistributionTreeListComponent } from './distribution/distribution-tree-list/distribution-tree-list.component';
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
    ToRezervListComponent,
    ToPbsListComponent,
    KuDetailListComponent,
    KuDetailEntityComponent,
    ToRezervEntityComponent,
    ToPbsEntityComponent,
    DistributionHeaderComponent,
    DistributionTreeListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DxMenuModule,
    DxBulletModule,
    DxTemplateModule,
    DxDataGridModule,
    DxTreeListModule,
    DxButtonModule,
    DxTooltipModule,
    DxPopoverModule,
    DxTabPanelModule,
    DxFormModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxDateBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
