import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KuDetailEntityComponentComponent } from './distribution/ku-detail/entity/ku-detail-entity.component/ku-detail-entity.component.component';
import { KuDetailListComponentComponent } from './distribution/ku-detail/list/ku-detail-list.component/ku-detail-list.component.component';
import { ToPbsEntityComponentComponent } from './distribution/to-pbs/entity/to-pbs-entity.component/to-pbs-entity.component.component';
import { ToPbsListComponentComponent } from './distribution/to-pbs/list/to-pbs-list.component/to-pbs-list.component.component';
import { ToRezervEntityComponentComponent } from './distribution/to-rezerv/entity/to-rezerv-entity.component/to-rezerv-entity.component.component';
import { ToRezervListComponentComponent } from './distribution/to-rezerv/list/to-rezerv-list.component/to-rezerv-list.component.component';
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
    component: KuDetailListComponentComponent,
    data: {
        title: "Детализация КУ"
    }
  },
  {
    path: "distribution/ku-detail/item/:id",
    component: KuDetailEntityComponentComponent,
    data: {
        title: "Редактирование Детализации КУ"
    }
  },

  {
    path: "distribution/to-rezrv/list",
    component: ToRezervListComponentComponent,
    data: {
        title: "Распределение в резерв"
    }
  },
  {
    path: "distribution/to-rezrv/item/:id",
    component: ToRezervEntityComponentComponent,
    data: {
        title: "Редактирование Распределение в резерв"
    }
  },

  {
    path: "distribution/to-pbs/list",
    component: ToPbsListComponentComponent,
    data: {
        title: "Распределение по ПБС"
    }
  },
  {
    path: "distribution/to-pbs/item/:id",
    component: ToPbsEntityComponentComponent,
    data: {
        title: "Редактирование Распределение по ПБС"
    }
  },

  {
    path: "",
    redirectTo: "rad/doc/item/1097323990887",
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
