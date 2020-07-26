import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "answer-edit",
  templateUrl: './answer-edit.component.html',
  styleUrls: ['./answer-edit.component.css']
})

export class AnswerEditComponent {
  title: string;
  answer: Answer;
  // will be true if question exists and false when does not exists
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.answer = <Answer>{};
    var id = +this.activatedRoute.snapshot.params["id"];

    this.editMode = (this.activatedRoute.snapshot.url[1].path === "edit");

    if (this.editMode) {
      var url = this.baseUrl + "api/answer/" + id;
      this.http.get<Answer>(url).subscribe(result => {
        this.answer = result;
        this.title = "Edit - " + this.answer.Text;
      });
    }
    else {
      this.answer.AnswerId = id;
      this.title = "Create new answer";
    }
  }

  onSubmit(answer: Answer) {
    var url = this.baseUrl + "api/answer";

    if (this.editMode) {
      this.http.post<Answer>(url, answer).subscribe(result => {
        var v = result;
        this.router.navigate(["answer/edit", v.AnswerId]);
      });
    }
    else {
      this.http.put<Answer>(url, answer).subscribe(result => {
        var v = result;
        this.router.navigate(["answer/edit", v.AnswerId]);
      });
    }
  }

  onBack() {
    this.router.navigate(["answer/edit", this.answer.AnswerId]);
  }

}
