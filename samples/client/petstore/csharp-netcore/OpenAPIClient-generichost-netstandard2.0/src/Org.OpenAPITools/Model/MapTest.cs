// <auto-generated>
/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using OpenAPIClientUtils = Org.OpenAPITools.Client.ClientUtils;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// MapTest
    /// </summary>
    public partial class MapTest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapTest" /> class.
        /// </summary>
        /// <param name="directMap">directMap</param>
        /// <param name="indirectMap">indirectMap</param>
        /// <param name="mapMapOfString">mapMapOfString</param>
        /// <param name="mapOfEnumString">mapOfEnumString</param>
        [JsonConstructor]
        public MapTest(Dictionary<string, bool> directMap, Dictionary<string, bool> indirectMap, Dictionary<string, Dictionary<string, string>> mapMapOfString, Dictionary<string, MapTest.InnerEnum> mapOfEnumString)
        {
            DirectMap = directMap;
            IndirectMap = indirectMap;
            MapMapOfString = mapMapOfString;
            MapOfEnumString = mapOfEnumString;
            OnCreated();
        }

        partial void OnCreated();

        /// <summary>
        /// Defines Inner
        /// </summary>
        public enum InnerEnum
        {
            /// <summary>
            /// Enum UPPER for value: UPPER
            /// </summary>
            UPPER = 1,

            /// <summary>
            /// Enum Lower for value: lower
            /// </summary>
            Lower = 2
        }

        /// <summary>
        /// Returns a InnerEnum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static InnerEnum InnerEnumFromString(string value)
        {
            if (value == "UPPER")
                return InnerEnum.UPPER;

            if (value == "lower")
                return InnerEnum.Lower;

            throw new NotImplementedException($"Could not convert value to type InnerEnum: '{value}'");
        }

        /// <summary>
        /// Returns equivalent json value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string InnerEnumToJsonValue(InnerEnum value)
        {
            if (value == InnerEnum.UPPER)
                return "UPPER";

            if (value == InnerEnum.Lower)
                return "lower";

            throw new NotImplementedException($"Value could not be handled: '{value}'");
        }

        /// <summary>
        /// Gets or Sets DirectMap
        /// </summary>
        [JsonPropertyName("direct_map")]
        public Dictionary<string, bool> DirectMap { get; set; }

        /// <summary>
        /// Gets or Sets IndirectMap
        /// </summary>
        [JsonPropertyName("indirect_map")]
        public Dictionary<string, bool> IndirectMap { get; set; }

        /// <summary>
        /// Gets or Sets MapMapOfString
        /// </summary>
        [JsonPropertyName("map_map_of_string")]
        public Dictionary<string, Dictionary<string, string>> MapMapOfString { get; set; }

        /// <summary>
        /// Gets or Sets MapOfEnumString
        /// </summary>
        [JsonPropertyName("map_of_enum_string")]
        public Dictionary<string, MapTest.InnerEnum> MapOfEnumString { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalProperties { get; } = new Dictionary<string, JsonElement>();

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MapTest {\n");
            sb.Append("  DirectMap: ").Append(DirectMap).Append("\n");
            sb.Append("  IndirectMap: ").Append(IndirectMap).Append("\n");
            sb.Append("  MapMapOfString: ").Append(MapMapOfString).Append("\n");
            sb.Append("  MapOfEnumString: ").Append(MapOfEnumString).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// A Json converter for type MapTest
    /// </summary>
    public class MapTestJsonConverter : JsonConverter<MapTest>
    {
        /// <summary>
        /// A Json reader.
        /// </summary>
        /// <param name="utf8JsonReader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override MapTest Read(ref Utf8JsonReader utf8JsonReader, Type typeToConvert, JsonSerializerOptions jsonSerializerOptions)
        {
            int currentDepth = utf8JsonReader.CurrentDepth;

            if (utf8JsonReader.TokenType != JsonTokenType.StartObject && utf8JsonReader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            JsonTokenType startingTokenType = utf8JsonReader.TokenType;

            Dictionary<string, bool> directMap = default;
            Dictionary<string, bool> indirectMap = default;
            Dictionary<string, Dictionary<string, string>> mapMapOfString = default;
            Dictionary<string, MapTest.InnerEnum> mapOfEnumString = default;

            while (utf8JsonReader.Read())
            {
                if (startingTokenType == JsonTokenType.StartObject && utf8JsonReader.TokenType == JsonTokenType.EndObject && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (startingTokenType == JsonTokenType.StartArray && utf8JsonReader.TokenType == JsonTokenType.EndArray && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (utf8JsonReader.TokenType == JsonTokenType.PropertyName && currentDepth == utf8JsonReader.CurrentDepth - 1)
                {
                    string propertyName = utf8JsonReader.GetString();
                    utf8JsonReader.Read();

                    switch (propertyName)
                    {
                        case "direct_map":
                            if (utf8JsonReader.TokenType != JsonTokenType.Null)
                                directMap = JsonSerializer.Deserialize<Dictionary<string, bool>>(ref utf8JsonReader, jsonSerializerOptions);
                            break;
                        case "indirect_map":
                            if (utf8JsonReader.TokenType != JsonTokenType.Null)
                                indirectMap = JsonSerializer.Deserialize<Dictionary<string, bool>>(ref utf8JsonReader, jsonSerializerOptions);
                            break;
                        case "map_map_of_string":
                            if (utf8JsonReader.TokenType != JsonTokenType.Null)
                                mapMapOfString = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(ref utf8JsonReader, jsonSerializerOptions);
                            break;
                        case "map_of_enum_string":
                            if (utf8JsonReader.TokenType != JsonTokenType.Null)
                                mapOfEnumString = JsonSerializer.Deserialize<Dictionary<string, MapTest.InnerEnum>>(ref utf8JsonReader, jsonSerializerOptions);
                            break;
                        default:
                            break;
                    }
                }
            }

            if (mapMapOfString == null)
                throw new ArgumentNullException(nameof(mapMapOfString), "Property is required for class MapTest.");

            if (mapOfEnumString == null)
                throw new ArgumentNullException(nameof(mapOfEnumString), "Property is required for class MapTest.");

            if (directMap == null)
                throw new ArgumentNullException(nameof(directMap), "Property is required for class MapTest.");

            if (indirectMap == null)
                throw new ArgumentNullException(nameof(indirectMap), "Property is required for class MapTest.");

            return new MapTest(directMap, indirectMap, mapMapOfString, mapOfEnumString);
        }

        /// <summary>
        /// A Json writer
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="mapTest"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, MapTest mapTest, JsonSerializerOptions jsonSerializerOptions)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("direct_map");
            JsonSerializer.Serialize(writer, mapTest.DirectMap, jsonSerializerOptions);
            writer.WritePropertyName("indirect_map");
            JsonSerializer.Serialize(writer, mapTest.IndirectMap, jsonSerializerOptions);
            writer.WritePropertyName("map_map_of_string");
            JsonSerializer.Serialize(writer, mapTest.MapMapOfString, jsonSerializerOptions);
            writer.WritePropertyName("map_of_enum_string");
            JsonSerializer.Serialize(writer, mapTest.MapOfEnumString, jsonSerializerOptions);

            writer.WriteEndObject();
        }
    }
}
