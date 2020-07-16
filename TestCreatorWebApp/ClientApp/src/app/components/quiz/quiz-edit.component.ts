import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "quiz-edit",
  templateUrl: './quiz-edit.component.html',
  styleUrls: ['./quiz-edit.component.css']
})

export class QuizEditComponent {
  title: string;
  quiz: Quiz;
  // true if quiz exists, false when creating new quiz
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.quiz = <Quiz>{};
    var id = +this.activatedRoute.snapshot.params["id"];

    if (id) {
      this.editMode = true;
      var url = this.baseUrl + "api/quiz/" + id;

      this.http.get<Quiz>(url).subscribe(result => {
        this.quiz = result;
        this.title = "Edit - " + this.quiz.Title;
      });
    }
    else {
      this.editMode = false;
      this.title = "Create new quiz";
    }
  }

  onSubmit(quiz: Quiz) {
    var url = this.baseUrl + "api/quiz";

    if (this.editMode) {
      this.http.put<Quiz>(url, quiz).subscribe(result => {
        this.router.navigate(["home"]);
      });
    }
    else {
      this.http.post<Quiz>(url, quiz).subscribe(result => {
        this.router.navigate(["home"]);
      });
    }
  }

  onBack() {
    this.router.navigate(["home"]);
  }
}
