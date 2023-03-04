/*
 * Copyright 2018 OpenAPI-Generator Contributors (https://openapi-generator.tech)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package org.openapitools.codegen.elm;

import io.swagger.v3.oas.models.Operation;
import io.swagger.v3.oas.models.media.ArraySchema;
import io.swagger.v3.oas.models.media.DateTimeSchema;
import io.swagger.v3.oas.models.media.Schema;
import io.swagger.v3.oas.models.media.UUIDSchema;
import io.swagger.v3.oas.models.parameters.QueryParameter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import org.openapitools.codegen.CodegenOperation;
import org.openapitools.codegen.languages.ElmClientCodegen;
import org.openapitools.codegen.model.OperationMap;
import org.openapitools.codegen.model.OperationsMap;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

@SuppressWarnings("static-method")
public class ElmClientCodegenTest {
    @DataProvider(name = "recursive-lists-of-uuid")
    private static Schema[] recursiveListOfUuids() {
        return recursiveListOfType(new UUIDSchema(), 6);
    }

    @Test(description = "Operation that takes list of UUID (and recursive lists of UUID) includes import from UUID", dataProvider = "recursive-lists-of-uuid")
    public void operationThatTakesListOfListOfUuidImportsUuid(Schema p) throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        Operation operation = new Operation()
                .operationId("opId")
                .addParametersItem(new QueryParameter().name("listOfUuid").schema(p));

        CodegenOperation co = codegen.fromOperation("/some/path", "get", operation, null);

        OperationMap operationMap = new OperationMap();
        operationMap.setOperation(co);

        OperationsMap operationsMap = new OperationsMap();
        operationsMap.setOperation(operationMap);

        OperationsMap postProcessed = codegen.postProcessOperationsWithModels(operationsMap, Collections.emptyList());

        Assert.assertEquals(postProcessed.get("includeUuid"), true);
    }

    @DataProvider(name = "recursive-lists-of-datetime")
    private static Schema[] recursiveListOfDateTime() {
        return recursiveListOfType(new DateTimeSchema(), 6);
    }

    @Test(description = "Operation that takes list of DateTime (and recursive lists of DateTime) includes import from Api.Time", dataProvider = "recursive-lists-of-datetime")
    public void operationThatTakesListOfListOfDateTimeImportsApiTime(Schema p) throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        Operation operation = new Operation()
                .operationId("opId")
                .addParametersItem(new QueryParameter().name("listOfDateTime").schema(p));

        CodegenOperation co = codegen.fromOperation("/some/path", "get", operation, null);

        OperationMap operationMap = new OperationMap();
        operationMap.setOperation(co);

        OperationsMap operationsMap = new OperationsMap();
        operationsMap.setOperation(operationMap);

        OperationsMap postProcessed = codegen.postProcessOperationsWithModels(operationsMap, Collections.emptyList());

        Assert.assertEquals(postProcessed.get("includeTime"), true);
    }

    @Test(description = "operations starting with numbers are prefixed correctly")
    public void operationsStartingWithNumbersArePrefixedCorrectly() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        String operationId = codegen.toOperationId("200Response");
        Assert.assertEquals(operationId, "call200response");
    }

    @Test(description = "decimal is converted to Float")
    public void decimalIsConvertedToFloat() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        Schema schema = new Schema().addProperty("amount", new StringSchema().format("number"));

        OpenAPI openApi = TestUtils.createOpenAPIWithOneSchema("test", schema);

        codegen.setOpenAPI(openApi);
        final CodegenModel cm1 = codegen.fromModel("sample", schema);

        Assert.assertEquals(cm1.vars.get(0).dataType, "Float");
    }

    @Test(description = "record field starting with number should be prefixed")
    public void recordFieldStartingWithNumberShouldBePrefixed() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        String modelName = codegen.toVarName("123list");
        Assert.assertEquals(modelName, "f123list");
    }

    @Test(description = "type starting with number is prefixed correctly")
    public void typeStartingWithNumbersArePrefixedCorrectly() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        String modelName = codegen.toModelName("200Response");
        Assert.assertEquals(modelName, "Type200Response");
    }

    @Test(description = "type with same name as default include is suffixed")
    public void typeWithSameNameAsDefaultIncludeIsSuffixed() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        String modelName = codegen.toModelName("List");
        Assert.assertEquals(modelName, "List_");
    }

    @Test(description = "type with invalid characters are escaped")
    public void typeWithInvalidCharactersAreEscaped() throws Exception {
        final ElmClientCodegen codegen = new ElmClientCodegen();

        String typeName = codegen.toModelName("EnumArraysJustSymbol&gt;&#x3D;");
        Assert.assertEquals(typeName, "EnumArraysJustSymbol");
    }

    // HELPERS
    private static <TSchema extends Schema> Schema[] recursiveListOfType(TSchema type, int levelsOfRecursion) {
        final List<Schema> output = new ArrayList<Schema>();

        for (int levels = 0; levels < levelsOfRecursion; ++levels) {
            ArraySchema baseSchema = new ArraySchema();
            ArraySchema current = baseSchema;
            for (int level = 0; level < levels; ++level) {
                ArraySchema child = new ArraySchema();

                current.items(child);
                current = child;
            }
            current.items(type);
            output.add(baseSchema);
        }

        return output.toArray(new Schema[0]);
    }
}
