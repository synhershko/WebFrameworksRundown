package com.code972.sample.webapp;

/**
 * Created with IntelliJ IDEA.
 * User: synhershko
 * Date: 10/6/13
 * Time: 7:13 PM
 * To change this template use File | Settings | File Templates.
 */
public class ErrorResponse {
    public ErrorResponse(String message) {
        this.message = message;
    }

    public ErrorResponse(String message, Exception ex) {
        this.message = message;
        innerException = ex;
    }

    public String message;
    public Exception innerException;
}
