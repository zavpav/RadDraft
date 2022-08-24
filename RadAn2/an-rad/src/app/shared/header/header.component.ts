import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Params, Router, RoutesRecognized } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public title!: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    // тут нет ActiveRoute потому что контрол вне router-outlet
    this.router.events.subscribe(data => {
      if (data instanceof RoutesRecognized){
        const d = data as RoutesRecognized;
        console.log(d)
        this.title = d.state.root.firstChild?.data["title"]
      }
    })

  }

}
