import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "question-edit",
  templateUrl: './question-edit.component.html',
  styleUrls: ['./question-edit.component.css']
})

export class QuestionEditComponent {
  title: string;
  question: Question;
  // will be true if question exists and false when does not exists
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.question = <Question>{};
    var id = +this.activatedRoute.snapshot.params["id"];

    this.editMode = (this.activatedRoute.snapshot.url[1].path === "edit");

    if (this.editMode) {
      var url = this.baseUrl + "api/question/" + id;
      this.title = "Edit question";

      this.http.get<Question>(url).subscribe(result => {
        this.question = result;
      });
    }
    else {
      this.question.QuizId = id;
      this.title = "Create new question";
    }
  }

  onSubmit(question: Question) {
    var url = this.baseUrl + "api/question";

    if (this.editMode) {
      this.http.put<Question>(url, question).subscribe(result => {
        var v = result;
        this.router.navigate(["quiz/edit", v.QuizId]);
      });
    }
    else {
      this.http.post<Question>(url, question).subscribe(result => {
        var v = result;
        this.router.navigate(["quiz/edit", v.QuizId]);
      });
    }
  }

  onBack() {
    this.router.navigate(["quiz/edit", this.question.QuizId]);
  }

}
