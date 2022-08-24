import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.scss']
})
export class NotFoundComponent implements OnInit {

  public title!: string;

  constructor(private activeRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.title = this.activeRoute.snapshot.data['title'];
  }

}
