package com.code972.sample.webapp;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import spark.ResponseTransformerRoute;

/**
 * Created with IntelliJ IDEA.
 * User: synhershko
 * Date: 10/1/13
 * Time: 2:34 PM
 * To change this template use File | Settings | File Templates.
 */
public abstract class JsonTransformer extends ResponseTransformerRoute {

    private static ObjectMapper mapper = new ObjectMapper();

    protected JsonTransformer(String path) {
        super(path);
    }

    protected JsonTransformer(String path, String acceptType) {
        super(path, acceptType);
    }

    @Override
    public String render(Object model) {
        if (model == null)
            return "";

        if (model instanceof String)
            return (String)model;

        try {
            return mapper.writeValueAsString(model);
        } catch (JsonProcessingException e) {
            return "{ \"error\" : \"" + e.getMessage() + "\" }";
        }
    }
}
