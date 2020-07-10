import { HttpClient } from "@angular/common/http";
import { Component, Inject, Input, OnInit } from "@angular/core";

@Component({
  selector: "quiz-list",
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent implements OnInit {
  @Input() class: string;
  title: string;
  selectedQuiz: Quiz;
  quizzes: Quiz[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    var url = this.baseUrl + "api/quiz/";

    switch (this.class) {
    case "latest":
    default:
      this.title = "Newest quizzes";
      url += "Latest/";
      break;
    case "byTitle":
      this.title = "Alphabetical quizzes";
      url += "byTitle/";
      break;
    case "random":
      this.title = "Random quizzes";
      url += "random/";
      break;
    }

    this.http.get<Quiz[]>(url).subscribe(result => {
      this.quizzes = result;
    }, error => console.error(error));
  }

  onSelect(quiz: Quiz) {
    this.selectedQuiz = quiz;
  }
}
