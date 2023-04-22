{-
   OpenAPI Petstore
   This is a sample server Petstore server. For this sample, you can use the api key `special-key` to test the authorization filters.

   The version of the OpenAPI document: 1.0.0

   NOTE: This file is auto generated by the openapi-generator.
   https://github.com/openapitools/openapi-generator.git

   DO NOT EDIT THIS FILE MANUALLY.

   For more info on generating Elm code, see https://eriktim.github.io/openapi-elm/
-}


module Api.Request.Store exposing
    ( deleteOrder
    , getInventory
    , getOrderById
    , placeOrder
    )

import Api
import Api.Data exposing (..)
import Dict
import Http
import Json.Decode
import Json.Encode

{-| For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors
-}
deleteOrder : { orderId : String } -> Api.Request ()
deleteOrder { orderId_path } =
    Api.request
        "DELETE"
        "/store/order/{orderId}"
        [ ( "orderId", identity orderId_path ) ]
        []
        []
        Nothing
        (Json.Decode.succeed ())


{-| Returns a map of status codes to quantities
-}
getInventory : Api.Request (Dict.Dict String Int)
getInventory =
    Api.request
        "GET"
        "/store/inventory"
        []
        []
        []
        Nothing
        (Json.Decode.dict Json.Decode.int)


{-| For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions
-}
getOrderById : { orderId : Int } -> Api.Request Api.Data.Order_
getOrderById { orderId_path } =
    Api.request
        "GET"
        "/store/order/{orderId}"
        [ ( "orderId", String.fromInt orderId_path ) ]
        []
        []
        Nothing
        Api.Data.orderDecoder


placeOrder : { order : Api.Data.Order_ } -> Api.Request Api.Data.Order_
placeOrder { order_body } =
    Api.request
        "POST"
        "/store/order"
        []
        []
        []
        (Maybe.map Http.jsonBody (Just (Api.Data.encodeOrder order_body)))
        Api.Data.orderDecoder

