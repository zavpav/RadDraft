import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
    component: SprRadEditComponent,
    data: {
      title: "Просмотр/редактирование документов РАД"
    }
  },

  {
    path: "",
    redirectTo: "rad/spr/list",
    pathMatch: "full"
  },
  {
    path: "**",
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
