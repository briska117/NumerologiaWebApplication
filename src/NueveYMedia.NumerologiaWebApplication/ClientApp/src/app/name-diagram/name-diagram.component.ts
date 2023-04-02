import { Component, Input, OnInit } from '@angular/core';
import { NumericalAnalisys } from '../models/models';

@Component({
  selector: 'app-name-diagram',
  templateUrl: './name-diagram.component.html',
  styleUrls: ['./name-diagram.component.css']
})
export class NameDiagramComponent implements OnInit {

  @Input() numericalAnalisys!: NumericalAnalisys;

  constructor() { }

  ngOnInit(): void {
  }
  countElements() { }

}
