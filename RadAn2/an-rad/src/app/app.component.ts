import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'an-rad';

  visibleDefault : boolean = false;
  toggleDefault(v:any):void{

    this.visibleDefault = !this.visibleDefault
  }
}
