import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Router } from '@angular/router';

class Recipe {
  private id: number;
  private name: string;
  private imgUrl: string;

  constructor(id, name, imgUrl) {
    this.id = id;
    this.name = name;
    this.imgUrl = imgUrl;
  }
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  options: FormGroup;
  recipes: Recipe[] = [
    new Recipe(0, "Bla1", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png"),
    new Recipe(1, "Bla2", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png"),
    new Recipe(2, "Bla3", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png"),
    new Recipe(3, "Bla4", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png"),
    new Recipe(4, "Bla5", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png"),
    new Recipe(5, "Bla6", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png")];
  dailyrecipe: Recipe = new Recipe(0, "Bla1", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png");
  bestrecipe: Recipe = new Recipe(0, "Bla1", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190611-mandarin-orange-salad-281-landscape-pf-1561556605.png");

  constructor(fb: FormBuilder, private dataService: DataService, private router: Router) {

    this.options = fb.group({
      bottom: 0,
      fixed: true,
      top: 0
    });
  }

  ngOnInit() {
    //get daily
    //get best
    //get all
  }

  onClick(id: number) {
    this.dataService.recipeId = id;
    this.router.navigate(["recipeInfo"]);
  }
}
