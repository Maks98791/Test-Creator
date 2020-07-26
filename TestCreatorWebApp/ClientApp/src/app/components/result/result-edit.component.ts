import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "result-edit",
  templateUrl: './result-edit.component.html',
  styleUrls: ['./result-edit.component.css']
})

export class ResultEditComponent {
  title: string;
  result: Result;
  // will be true if question exists and false when does not exists
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.result = <Result>{};
    var id = +this.activatedRoute.snapshot.params["id"];

    this.editMode = (this.activatedRoute.snapshot.url[1].path === "edit");

    if (this.editMode) {
      var url = this.baseUrl + "api/result/" + id;
      this.title = "Edit Result";

      this.http.get<Result>(url).subscribe(result => {
        this.result = result;
      });
    }
    else {
      this.result.QuizId = id;
      this.title = "Create new result";
    }
  }

  onSubmit(result: Result) {
    var url = this.baseUrl + "api/result";

    if (this.editMode) {
      this.http.put<Result>(url, result).subscribe(result => {
        var v = result;
        this.router.navigate(["result/edit", v.QuizId]);
      });
    }
    else {
      this.http.post<Result>(url, result).subscribe(result => {
        var v = result;
        this.router.navigate(["result/edit", v.QuizId]);
      });
    }
  }

  onBack() {
    this.router.navigate(["result/edit", this.result.QuizId]);
  }

}
