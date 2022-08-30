import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rad-item',
  templateUrl: './rad-item.component.html',
})
export class RadItemComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  selectedId!: number;

  getId(): number{
    let a= this.route;
    
    return 1;
  }
  
  ngOnInit(): void {
    this.selectedId = Number(this.route.snapshot.params["id"]);
  }

}
