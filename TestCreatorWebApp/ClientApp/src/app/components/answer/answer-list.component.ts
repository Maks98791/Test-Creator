import { OnChanges, Component, Input, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { SimpleChanges } from "@angular/core/core";

@Component({
  selector: "answer-list",
  templateUrl: './answer-list.component.html',
  styleUrls: ['./answer-list.component.css']
})

export class AnswerListComponent implements OnChanges {
  @Input() question: Question;
  answers: Answer[];
  title: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.answers = [];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes['question'] !== "undefined") {
      // get info from key: question
      var change = changes['question'];

      if (!change.isFirstChange()) {
        this.loadData();
      }
    }
  }

  loadData() {
    var url = this.baseUrl + "api/answer/all/" + this.question.QuestionId;
    this.http.get<Answer[]>(url).subscribe(result => {
      this.answers = result;
    });
  }

  onCreate() {
    this.router.navigate(["./answer/create", this.question.QuestionId]);
  }

  onEdit(answer: Answer) {
    this.router.navigate(["./answer/edit", answer.AnswerId]);
  }

  onDelete(answer: Answer) {
    if (confirm("Are you sure you want to delete this answer?")) {
      var url = this.baseUrl + "api/answer/" + answer.AnswerId;
      this.http.delete(url).subscribe(result => {
        this.loadData();
      })
    }
  }
}
