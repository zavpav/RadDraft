import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RadItemComponent } from './rad-spr/rad-item/rad-item.component';

import { RadListComponent } from './rad-spr/rad-list.component';

const routes: Routes = [
  {
    path: "spr-rad",
    component: RadListComponent,
    data: { title:"Данные РАД" }
  },
  {
    path: "",
    redirectTo: "spr-rad",
    pathMatch: "full"
  },
  {
    path: "spr-rad/:id", 
    component: RadItemComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
