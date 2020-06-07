import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { HttpClient } from '@angular/common/http';

class Ingredient {
  private id: number;
  private title: string;
  private amount: number;

  constructor(id, title, amount) {
    this.id = id;
    this.title = title;
    this.amount = amount;
  }
}

class Recipe {
  private id: number;
  private title: string;
  private description: string;
  private mealType: string;
  private sideNote: string;
  private imgUrl: string;

  public ingredients: Ingredient[];

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
  selector: 'app-recipeinfo',
  templateUrl: './recipeinfo.component.html',
  styleUrls: ['./recipeinfo.component.css']
})
export class RecipeinfoComponent implements OnInit {

  private recipe: Recipe;

  constructor(private router: Router, private dataService: DataService, private httpClient: HttpClient) { }

  ngOnInit() {

    if (this.dataService.recipeId === -1 || this.dataService.recipeId === undefined) this.router.navigate([""]);



    this.httpClient.get("/recipe/get?id=" + this.dataService.recipeId)
      .subscribe(
        data => {
          this.recipe = new Recipe(data['id'], data['title'], data['description'], data['mealType'], data['sideNote'], data['imgUrl']);
        },
        error => {
          console.log(error);
        });

    this.httpClient.get("/recipe/getIngredients?id=" + this.dataService.recipeId)
      .subscribe(
        data => {
          this.recipe.ingredients = data['ingredients'];
        },
        error => {
          console.log(error);
        }); 

  }

}
