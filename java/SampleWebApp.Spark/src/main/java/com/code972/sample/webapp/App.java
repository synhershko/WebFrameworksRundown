package com.code972.sample.webapp;

import org.apache.commons.lang.StringEscapeUtils;
import org.apache.commons.lang.StringUtils;
import spark.Request;
import spark.Response;
import spark.Route;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import static spark.Spark.get;
import static spark.Spark.post;

/**
 * Hello world!
 *
 */
public class App 
{
    private static org.apache.log4j.Logger logger   = org.apache.log4j.Logger.getLogger(App.class);

    public static void main( String[] args ) throws IOException {

        get(new Route("/api/status") {
            @Override
            public Object handle(Request request, Response response) {
                response.header("Access-Control-Allow-Origin", "*");

                response.type("text/plain; charset=UTF-8");
                return "{ \"foo\": \"active\" }";
            }
        });

        get(new com.code972.sample.webapp.JsonTransformer("/api/content/parser") {
            @Override
            public Object handle(Request request, Response response) {
                response.header("Access-Control-Allow-Origin", "*");
                response.type("text/plain; charset=UTF-8");

                final String url = request.queryParams("url");

                // if unsuccessful, do scraping
                try {
                    return StringEscapeUtils.unescapeHtml(url).replaceAll("\\<[^>]*>","");
                } catch (Exception e) {
                    response.status(500);
                    return new ErrorResponse("Failed to read " + url, e);
                }
            }

            protected BufferedReader sendGet(final URL url) throws Exception {
                HttpURLConnection con = (HttpURLConnection) url.openConnection();
                con.setRequestMethod("GET");

                int responseCode = con.getResponseCode();

                return new BufferedReader(new InputStreamReader(con.getInputStream()));
            }
        });
    }
}
