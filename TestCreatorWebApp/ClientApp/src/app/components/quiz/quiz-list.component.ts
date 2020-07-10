import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";

@Component({
  selector: "quiz-list",
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent {
  title: string;
  selectedQuiz: Quiz;
  quizzes: Quiz[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.title = "Newest quizzes";
    var url = baseUrl + "api/quiz/Latest";

    http.get<Quiz[]>(url).subscribe(result => {
        this.quizzes = result;
      }, error => console.error(error));
  }

  onSelect(quiz: Quiz) {
    this.selectedQuiz = quiz;
  }
}
