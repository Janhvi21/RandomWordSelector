import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WebdriverWebElement } from 'protractor/built/element';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {
  public demo: String;
  commandRunning: boolean = false;
  currentWord: string;
  timeRemaining: number;
  public wordListInput: string;
  onButtonPress() {
    console.log(this.wordListInput);
    if (this.wordListInput !== "" && this.wordListInput !== undefined) {
      let webSocket = new WebSocket(environment.wsURL);
      webSocket.onopen = () => {
        console.log("Open");
        webSocket.send(this.wordListInput);
      };
      webSocket.onmessage = (evt) => {
        console.log(webSocket.OPEN);
        if (webSocket.OPEN) {
          var str = evt.data.split(",");
          this.updateData(str);
          webSocket.send("");
        } else {
          clearInterval();
        }
      };
      webSocket.onclose = () => {
        webSocket.close(1000, "Closed");
        this.commandRunning = false;
        this.currentWord = "";
        this.timeRemaining = null;
      };
      webSocket.onerror = function (evt) {
        console.log("ERR: " + evt.type);
      };
    }
  }
  updateData(str) {
    this.commandRunning = str[0];
    this.currentWord = str[1];
    this.timeRemaining = str[2];
  }
}

class Command {
  commandRunning: boolean;
  currentWord: string;
  timeRemaining: number;
}
