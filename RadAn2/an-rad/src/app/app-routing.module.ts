import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KuDetailEntityComponent } from './distribution/ku-detail/entity/ku-detail-entity/ku-detail-entity.component';
import { KuDetailListComponent } from './distribution/ku-detail/list/ku-detail-list/ku-detail-list.component';
import { ToPbsEntityComponent } from './distribution/to-pbs/entity/to-pbs-entity/to-pbs-entity.component';
import { ToPbsListComponent } from './distribution/to-pbs/list/to-pbs-list/to-pbs-list.component';
import { ToRezervEntityComponent } from './distribution/to-rezerv/entity/to-rezerv-entity/to-rezerv-entity.component';
import { ToRezervListComponent } from './distribution/to-rezerv/list/to-rezerv-list/to-rezerv-list.component';
import { DocRadItemComponent } from './rad/doc/doc-rad-item/doc-rad-item.component';
import { DocRadListComponent } from './rad/doc/doc-rad-list/doc-rad-list.component';
import { SprRadEditComponent } from './rad/spr/spr-rad-edit/spr-rad-edit.component';
import { SprRadListComponent } from './rad/spr/spr-rad-list/spr-rad-list.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';

const routes: Routes = [
  {
    path: "rad/spr/list",
    component: SprRadListComponent,
    data: {
      title: "Данные РАД"
    }
  },
  {
    path: "rad/spr/item/:id",
    component: SprRadEditComponent,
    data: {
      title: "Просмотр/редактирование данных РАД"
    }
  },

  {
    path: "rad/doc/list",
    component: DocRadListComponent,
    data: {
      title: "Документы РАД"
    }
  },
  {
    path: "rad/doc/item/:id",
    component: DocRadItemComponent,
    data: {
      title: "Просмотр/редактирование документов РАД"
    }
  },

  {
    path: "distribution/ku-detail/list",
    component: KuDetailListComponent,
    data: {
        title: "Детализация КУ"
    }
  },
  {
    path: "distribution/ku-detail/item/:id",
    component: KuDetailEntityComponent,
    data: {
        title: "Редактирование Детализации КУ"
    }
  },

  {
    path: "distribution/to-rezrv/list",
    component: ToRezervListComponent,
    data: {
        title: "Распределение в резерв"
    }
  },
  {
    path: "distribution/to-rezrv/item/:id",
    component: ToRezervEntityComponent,
    data: {
        title: "Редактирование Распределение в резерв"
    }
  },

  {
    path: "distribution/to-pbs/list",
    component: ToPbsListComponent,
    data: {
        title: "Распределение по ПБС"
    }
  },
  {
    path: "distribution/to-pbs/item/:id",
    component: ToPbsEntityComponent,
    data: {
        title: "Редактирование Распределение по ПБС"
    }
  },

  {
    path: "",
    redirectTo: "distribution/ku-detail/item/583562840567",
    pathMatch: "full"
  },
  {
    path: "**",
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes
    //, { enableTracing: true }
    )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
