package controllers;

import models.Question;
import play.*;
import play.mvc.*;

import views.html.*;

public class Application extends Controller {

    public static Result index() {
        return ok(index.render(new Question("foo")));
    }

}
