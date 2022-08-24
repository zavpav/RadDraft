import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

class MenuItem
{
  name!: string
  items?: MenuItem[] 
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit(): void {
    this.router.config
    this.menuItems = [{
      name: "Меню",
      items: [{name: "Подменю"}]
    },
    {name: "Ещё меню"}
  ]
  }

  showFirstSubmenuModes: any;
  menuItems!: MenuItem[];

  itemClick(data : any) : void {
    console.log(data)
  }

}
