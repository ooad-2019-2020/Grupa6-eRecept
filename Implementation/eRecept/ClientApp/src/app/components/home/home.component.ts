import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

class Recipe {
  private id: number;
  private title: string;
  private description: string;
  private mealType: string;
  private sideNote: string;
  public imgUrl: string;

  constructor(id, title, description, mealType, sideNote, imgUrl) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.mealType = mealType;
    this.sideNote = sideNote;
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
  recipes: Recipe[] = [];
  dailyrecipe: Recipe = new Recipe(null, null, null, null, null, null);
  bestrecipe: Recipe = new Recipe(null, null, null, null, null, null);
  
  constructor(fb: FormBuilder, private dataService: DataService, private router: Router, private httpClient: HttpClient) {

    this.options = fb.group({
      bottom: 0,
      fixed: true,
      top: 0
    });
  }

  ngOnInit() {
    //get daily
    this.httpClient.get("http://localhost:51943/recipe/getDaily")
      .subscribe(
        (data: Recipe) => {
          this.dailyrecipe = data;
        },
        error => {
          console.log(error);
        });
    //get best
    this.httpClient.get("http://localhost:51943/recipe/getBest")
      .subscribe(
        (data: Recipe) => {
          this.bestrecipe = data;
        },
        error => {
          console.log(error);
        });
    //getall
    this.httpClient.get("http://localhost:51943/recipe")
      .subscribe(
        (data: Recipe[]) => {
          this.recipes = data;
        },
        error => {
          console.log(error);
        }); 
  }

  onClick(id: number) {
    this.dataService.recipeId = id;
    this.router.navigate(["recipeInfo"]);
  }
}
