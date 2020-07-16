import { Component, Input, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "quiz",
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})

export class QuizComponent {
  quiz: Quiz;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    // utworzenie pustego obiektu quiz
    this.quiz = <Quiz>{};
    var id = +this.activatedRoute.snapshot.params["id"];
    console.log("wczytane id: " + id);

    if (id) {
      var url = this.baseUrl + "api/quiz/" + id;
      this.http.get<Quiz>(url).subscribe(result => {
        this.quiz = result;
      });
    } else {
      this.router.navigate(["home"]);
    }
  }

  onEdit() {
    this.router.navigate(["quiz/edit", this.quiz.QuizId]);
  }

  onDelete() {
    if (confirm("Are you sure you want to delete that quiz?")) {
      var url = this.baseUrl + "api/quiz/" + this.quiz.QuizId;

      this.http.delete(url).subscribe(result => {
        this.router.navigate(["home"]);
      })
    }
  }
}
