import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

import * as signalR from '@microsoft/signalr';
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class ServerNotifier {
    signalConnection: signalR.HubConnection;
    connectionId: any;

    constructor(){
        this.signalConnection = new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Information)
            .withUrl(environment.mainEndpoint + 'notify')
            .build();
        
        this.signalConnection
            .start()
            .then(() => {
                this.connectionId = this.signalConnection.connectionId;
            })
            .catch(x => {
                console.error("Notify Error ", x)
            })
    }

}