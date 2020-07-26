import { OnChanges, Component, Input, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { SimpleChanges } from "@angular/core/core";


@Component({
  selector: "question-list",
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})

export class QuestionListComponent implements OnChanges {
  @Input() quiz: Quiz;
  questions: Question[];
  title: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.questions = [];
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
    var url = this.baseUrl + "api/question/all/" + this.quiz.QuizId;
    this.http.get<Question[]>(url).subscribe(result => {
      this.questions = result;
    });
  }

  onCreate() {
    this.router.navigate(["/question/create", this.quiz.QuizId]);
  }

  onEdit(question: Question) {
    this.router.navigate(["/question/edit", question.QuestionId]);
  }

  onDelete(question: Question) {
    if (confirm("are you sure you want to delete that question?")) {
      var url = this.baseUrl + "api/question/" + question.QuestionId;
      this.http.delete(url).subscribe(result => {
        this.loadData();
      });
    }
  }
}
