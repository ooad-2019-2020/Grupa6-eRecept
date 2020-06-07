import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { HttpClient } from '@angular/common/http';
import { AuthGuardService } from '../../services/auth-guard.service';

class Ingredient {
  private id: number;
  private name: string;
  private amount: number;

  constructor(id, name, amount) {
    this.id = id;
    this.name = name;
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
  @Input() rating: number;
  @Input() itemId: number;
  @Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
  private feedbackMessage: string;
  private recipe: Recipe;

  constructor(private router: Router, private dataService: DataService, private httpClient: HttpClient, private authGuardService: AuthGuardService) { }

  ngOnInit() {

    if (this.dataService.recipeId === -1 || this.dataService.recipeId === undefined) this.router.navigate([""]);

    this.httpClient.get("http://localhost:51943/recipe/get?id=" + this.dataService.recipeId)
      .subscribe(
        (data: Recipe) => {
          this.recipe = data;

        },
        error => {
          console.log(error);
        });

    this.httpClient.get("http://localhost:51943/recipe/getIngredients?id=" + this.dataService.recipeId)
      .subscribe(
        (data: Ingredient[])=> {
          this.recipe.ingredients = data;
        },
        error => {
          console.log(error);
        }); 
  }
  onClick(rating: number): void {
    this.rating = rating;
    this.ratingClick.emit({
      itemId: this.itemId,
      rating: rating
    });
  }

  onSubmitFeedback() {
    //POZVATI FEEDBACK BACKEND
    const url = "http://localhost:51943/feedback/submit?rating=" + this.rating + "&comment=" + this.feedbackMessage + "&userId=" + this.authGuardService.userId + "&recipeId=" + this.dataService.recipeId;
    this.httpClient.post(url, null).subscribe(data => { console.log("Success!"); }, error => { console.log("Error"); });
  }
}
