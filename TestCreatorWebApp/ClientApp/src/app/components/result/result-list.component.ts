import { OnChanges, Component, Input, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { SimpleChanges } from "@angular/core/core";


@Component({
  selector: "result-list",
  templateUrl: './result-list.component.html',
  styleUrls: ['./result-list.component.css']
})

export class ResultListComponent implements OnChanges {
  @Input() quiz: Quiz;
  results: Result[];
  title: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.results = [];
  }

  ngOnChanges(changes: SimpleChanges) {

    if (typeof changes['quiz'] !== "undefined") {

      // get information about quiz changes
      var change = changes['quiz'];

      if (!change.isFirstChange()) {
        this.loadData();
      }
    }
  }

  loadData() {
    var url = this.baseUrl + "api/result/all/" + this.quiz.QuizId;
    this.http.get<Result[]>(url).subscribe(result => {
      this.results = result;
    });
  }

  onCreate() {
    this.router.navigate(["/result/create", this.quiz.QuizId]);
  }

  onEdit(result: Result) {
    this.router.navigate(["/result/edit", result.ResultId]);
  }

  onDelete(result: Result) {
    if (confirm("are you sure you want to delete that result?")) {
      var url = this.baseUrl + "api/result/" + result.ResultId;
      this.http.delete(url).subscribe(result => {
        this.loadData();
      });
    }
  }
}
