import { Component, OnInit } from '@angular/core';
import {Hero} from "../hero";
import {Heroes} from "../Mock-Hero";

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.scss']
})
export class HeroListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  herolist : Hero[] = Heroes;
  selectedHero? : Hero;

  changeHero(hero : Hero) {
    this.selectedHero = hero;
  }
}
